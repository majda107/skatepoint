using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skolu_nepobiram.Database;
using skolu_nepobiram.Database.Models;

namespace skolu_nepobiram.Controllers
{
    public class SkateController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IHttpContextAccessor _accessor;

        public SkateController(DatabaseContext db, IHttpContextAccessor accessor)
        {
            this._db = db;
            this._accessor = accessor;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPoint([FromBody] SkatePlace place)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = this._accessor.HttpContext.User;
            var userEntry = this._db.Users.Include(u => u.Places).FirstOrDefault(u => u.UserName == user.Identity.Name);

            if (userEntry == null) return Unauthorized();

            this._db.Add(place);
            await this._db.SaveChangesAsync();

            userEntry.Places.Add(place);
            await this._db.SaveChangesAsync();

            return new JsonResult(place);
        }

        [HttpGet]
        public async Task<IActionResult> GetPoints()
        {
            return new JsonResult(this._db.SkatePlaces);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyPoints()
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = this._accessor.HttpContext.User;
            var userEntry = this._db.Users.Include(u => u.Places).FirstOrDefault(u => u.UserName == user.Identity.Name);

            if (userEntry == null) return Unauthorized();

            return new JsonResult(userEntry.Places);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePoint([FromQuery] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entry = this._db.SkatePlaces.FirstOrDefault(t => t.Id == id);
            if (entry == null) return NotFound();

            this._db.Remove(entry);
            await this._db.SaveChangesAsync();

            return Ok();
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