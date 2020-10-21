using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using skolu_nepobiram.Database;
using skolu_nepobiram.Models;

namespace skolu_nepobiram.Controllers
{
    public class SchoolController : Controller
    {
        private readonly DatabaseContext _db;

        public SchoolController(DatabaseContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<IActionResult> SearchICO([FromQuery] string name)
        {
            var school = this._db.Schools.FirstOrDefault(s => s.FullName.ToLower().Contains(name.ToLower()));
            if (school == null) return NotFound();

            return Json(school);
        }


        [HttpGet]
        public async Task<IActionResult> GetInfections([FromQuery] string ico)
        {
            var school = this._db.Schools.FirstOrDefault(s => s.ICO == ico);
            if (school == null) return NotFound();

            var infections = this._db.ProvinceInfections.Where(i => i.ProvinceLau == school.Province);

            return new JsonResult(new SchoolInfectionModel()
            {
                School = school,
                Infections = infections.ToArray()
            });
        }
    }
}