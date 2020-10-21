using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using skolu_nepobiram.Database;
using skolu_nepobiram.Models;

namespace skolu_nepobiram.Controllers
{
    public class SchoolController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly HtmlDocument _notices;

        public SchoolController(DatabaseContext db)
        {
            this._db = db;

            var web = new HtmlWeb();
            this._notices = web.Load(@"https://onemocneni-aktualne.mzcr.cz/covid-19/stupne-pohotovosti/");
        }

        [HttpGet]
        public async Task<IActionResult> SearchICO([FromQuery] string name)
        {
            var schools = this._db.Schools.Where(s => s.FullName.ToLower().Contains(name.ToLower())).Take(10);
            // if (school == null) return NotFound();

            return Json(schools.ToArray());
        }


        [HttpGet]
        public async Task<IActionResult> GetInfections([FromQuery] string ico)
        {
            var school = this._db.Schools.FirstOrDefault(s => s.ICO == ico);
            if (school == null) return NotFound();

            var infections = this._db.ProvinceInfections.Where(i => i.ProvinceLau == school.Province).ToArray();
            var level = infections.Length > 0
                ? infections.Last().Infected >= 100 ? InfectionLevel.High : InfectionLevel.Low
                : InfectionLevel.None;

            return new JsonResult(new SchoolInfectionModel()
            {
                School = school,
                Infections = infections,
                Notice = this.parseNotice(school.Province),
                Level = level.ToString().ToLower()
            });
        }


        private string parseNotice(string province)
        {
            var node = this._notices.DocumentNode.SelectSingleNode(
                $"//div[contains(@id,'dalsi-informace-{province}')]");
            return node?.OuterHtml ?? "";
        }


        [HttpGet]
        public async Task<IActionResult> GetNotice([FromQuery] string province)
        {
            return new JsonResult(new
            {
                notice = this.parseNotice(province)
            });
        }
    }
}