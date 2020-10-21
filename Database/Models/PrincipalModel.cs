using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Database.Models
{
    public class PrincipalModel
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
    }
}