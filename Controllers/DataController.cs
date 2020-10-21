using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skolu_nepobiram.Database;
using skolu_nepobiram.Database.Models;

namespace skolu_nepobiram.Controllers
{
    public class DataController : Controller
    {
        private readonly DatabaseContext _db;

        public DataController(DatabaseContext db)
        {
            this._db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Test([FromBody] string text)
        {
            return Json(text);
        }

        [HttpPost]
        [RequestSizeLimit(500000000)] // 500 MB LIMIT
        // public async Task<IActionResult> LoadXML(IFormFileCollection files)
        public async Task<IActionResult> LoadSchoolXML()
        {
            // XmlDocument doc = new XmlDocument();
            // if (files.Count != 1) return BadRequest("Invalid file count!");
            //
            // var f = files.First();
            // using (var ms = new MemoryStream())
            // {
            //     await f.CopyToAsync(ms);
            //     doc.Load(ms);
            // }


            var xml = new XmlDocument();
            using (FileStream fs = new FileStream("skoly.xml", FileMode.Open))
            {
                xml.Load(fs);

                var root = xml.DocumentElement;
                // return new JsonResult(new {text = root.FirstChild.InnerText});

                // return new JsonResult(new {text = root.ChildNodes.Count});


                // var school1 = root.ChildNodes[2];
                // return new JsonResult(new
                // {
                //     ico = school1?["ICO"]?.InnerText,
                //     name = school1?["Reditelstvi"]?["RedPlnyNazev"]?.InnerText,
                //     email = school1?["Email1"]?.InnerText,
                //     capacity = school1?["SkolyaZarizeni"]?["SKolaKapacita"]?.InnerText
                // });

                for (int i = 1; i < root.ChildNodes.Count; i++)
                {
                    var school = root.ChildNodes[i];
                    var ico = school?["ICO"]?.InnerText;
                    if (ico == null) continue;

                    var entity = new SchoolModel()
                    {
                        ICO = ico,
                        FullName = school?["Reditelstvi"]?["RedPlnyNazev"]?.InnerText,
                        Email = school?["Email1"]?.InnerText,
                        Capacity = school?["SkolyaZarizeni"]?["SKolaKapacita"]?.InnerText,
                        CapacityUnit = school?["SkolyaZarizeni"]?["SkolaKapacitaJednotka"]?.InnerText,
                        Province = school?["Reditelstvi"]?["Okres"]?.InnerText
                    };

                    this._db.Schools.Add(entity);
                }

                await this._db.SaveChangesAsync();
            }

            return new OkResult();
        }
    }
}