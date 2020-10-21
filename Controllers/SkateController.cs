using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using skolu_nepobiram.Database;
using skolu_nepobiram.Database.Models;

namespace skolu_nepobiram.Controllers
{
    public class SkateController : Controller
    {
        private readonly DatabaseContext _db;

        public SkateController(DatabaseContext db)
        {
            this._db = db;
        }

        [HttpPost]
        public async Task<IActionResult> AddPoint([FromBody] SkatePlace place)
        {
            if (!ModelState.IsValid) return BadRequest();
            this._db.Add(place);
            await this._db.SaveChangesAsync();

            return new JsonResult(place);
        }

        [HttpGet]
        public async Task<IActionResult> GetKnownPlaces([FromQuery] string name)
        {
            if (!ModelState.IsValid) return BadRequest();

            var places = this._db.KnownPlaces.Where(p => p.Name.Contains(name)).Take(10);
            return new JsonResult(places);
        }
    }
}