using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Database.Models
{
    public class KnownPlace
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }

        public string Type { get; set; }
    }
}