using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Database.Models
{
    public class SkatePlace
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
    }
}