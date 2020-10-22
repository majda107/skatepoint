using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skolu_nepobiram.Database;
using skolu_nepobiram.Database.Models;
using skolu_nepobiram.Models;

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


        [HttpGet]
        [Route("/hackathon")]
        public async Task<IActionResult> Hackathon()
        {
            return new ObjectResult("Hackathon 2020. Tým Nepobírám.");
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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutPointImage(IFormCollection files, int id)
        {
            if (files.Count != 1) return BadRequest();
            var file = files.Files[0];

            var user = this._accessor.HttpContext.User;
            var userEntry = this._db.Users.Include(u => u.Places).FirstOrDefault(u => u.UserName == user.Identity.Name);
            var point = userEntry?.Places?.FirstOrDefault(p => p.Id == id) ?? null;

            if (point == null) return BadRequest();

            var name = $"{userEntry.UserName}-{point.Id}.jpg";
            using (var fs = new FileStream("Images/" + name, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            point.Image = name;
            await this._db.SaveChangesAsync();

            return new JsonResult(point);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutLike([FromQuery] bool like, [FromQuery] int id)
        {
            var user = this._accessor.HttpContext.User;
            var userEntry = this._db.Users.Include(u => u.Places).FirstOrDefault(u => u.UserName == user.Identity.Name);
            var point = this._db.SkatePlaces.Include(s => s.Liked).FirstOrDefault(p => p.Id == id);

            if (userEntry == null || point == null) return BadRequest();

            if (like && !point.Liked.Any(u => u.UserName == userEntry.UserName))
                point.Liked.Add(userEntry);
            else if (!like && point.Liked.Any(u => u.UserName == userEntry.UserName))
                point.Liked.Remove(userEntry);
            else return new ConflictResult();

            await this._db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPoints()
        {
            var places = this._db.SkatePlaces.Include(p => p.Liked).Select(p =>
                new SkatePlaceModel()
                {
                    Description = p.Description,
                    Id = p.Id,
                    Image = p.Image,
                    Lat = p.Lat,
                    Lng = p.Lng,
                    Liked = p.Liked.Select(u => u.UserName).ToArray(),
                    Name = p.Name,
                    Type = p.Type
                });

            return new JsonResult(places);
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