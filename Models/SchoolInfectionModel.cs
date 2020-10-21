using System.Collections;
using System.Collections.Generic;
using skolu_nepobiram.Database.Models;

namespace skolu_nepobiram.Models
{
    public class SchoolInfectionModel
    {
        public SchoolModel School { get; set; }
        public ICollection<CovidInfection> Infections { get; set; }
    }
}