using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace skolu_nepobiram.Database.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public IList<SkatePlace> Places { get; set; }
    }
}