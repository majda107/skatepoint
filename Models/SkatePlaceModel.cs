using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Models
{
    public class SkatePlaceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }

        public string Description { get; set; }
        public string Type { get; set; }

        public string Image { get; set; }

        public ICollection<string> Liked { get; set; }
    }
}