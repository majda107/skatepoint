using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skolu_nepobiram.Database;
using skolu_nepobiram.Database.Models;
using skolu_nepobiram.Models;

namespace skolu_nepobiram.Controllers
{
    public class DataController : Controller
    {
        private readonly DatabaseContext _db;

        public DataController(DatabaseContext db)
        {
            this._db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            return new JsonResult(new StatisticsModel()
            {
                SpotCount = this._db.SkatePlaces.Count(),
                PlaceCount = this._db.KnownPlaces.Count(),
                UserCount = this._db.Users.Count(),
                LikeCount = this._db.SkatePlaces.Sum(t => t.Liked.Count())
            });
        }

        [HttpPost]
        public async Task<IActionResult> LoadSpotsXML()
        {
            var xml = new XmlDocument();
            using (FileStream fs = new FileStream("spots.kml", FileMode.Open))
            {
                xml.Load(fs);

                var root = xml.DocumentElement.FirstChild;

                var r = new Regex("\"(?<src>.*?)\"");

                int i = 0;
                // var names = new List<string>();
                foreach (XmlNode node in root.ChildNodes)
                {
                    i++;
                    if (node.Name != "Placemark") continue;
                    // names.Add(node?["name"]?.InnerText ?? "");
                    var name = node?["name"].InnerText ?? "";
                    if (name == "") continue;

                    var coords = node?["Point"]?["coordinates"]?.InnerText.Split(",");

                    var image = node?["description"]?.InnerText ?? "";
                    var match = r.Match(image);

                    var entry = new SkatePlace()
                    {
                        Name = name + i.ToString(),
                        Lat = double.Parse(coords[1]),
                        Lng = double.Parse(coords[0]),
                        Type = "Stair",
                        Description = "Imported from open-data",
                        Image = match?.Groups["src"].Value ?? ""
                    };

                    // return new JsonResult(entry);
                    this._db.SkatePlaces.Add(entry);
                }

                await this._db.SaveChangesAsync();

                // return new JsonResult(names);
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoadTownsXML()
        {
            var xml = new XmlDocument();
            using (FileStream fs = new FileStream("towns.xml", FileMode.Open))
            {
                xml.Load(fs);

                var root = xml.DocumentElement;
                foreach (XmlNode node in root.ChildNodes)
                {
                    var name = node?["name"]?.InnerText ?? "";
                    if (name == "") continue;

                    this._db.KnownPlaces.Add(new KnownPlace()
                    {
                        Type = "Town",
                        Name = name,
                        Location = node?["region"].InnerText ?? ""
                    });
                }

                // return new JsonResult(new
                // {
                //     name = root.FirstChild?["name"].InnerText,
                //     region = root.FirstChild?["region"].InnerText
                // });
                await this._db.SaveChangesAsync();
            }

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> LoadTreesCSV()
        {
            using (FileStream fs = new FileStream("stromy.csv", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                sr.ReadLine(); // first line is pointless (SCHEMA)
                var line = sr.ReadLine();
                while (line != null)
                {
                    var split = line.Split(",");

                    if (split.Length >= 1)
                    {
                        var entry = new KnownPlace()
                        {
                            Name = split[1],
                            Location = split?[5] ?? "",
                            Type = "Tree"
                        };

                        this._db.KnownPlaces.Add(entry);
                    }


                    line = sr.ReadLine();
                }

                await this._db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}