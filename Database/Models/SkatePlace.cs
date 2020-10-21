using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Database.Models
{
    public class SkatePlace
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }

        public string Description { get; set; }
        public string Type { get; set; }

        public string Image { get; set; }
    }
}