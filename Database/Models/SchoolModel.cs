using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Database.Models
{
    public class SchoolModel
    {
        [Key] public string ICO { get; set; }

        public string FullName { get; set; }
        public string PrincipalName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Capacity { get; set; }
        public string CapacityUnit { get; set; }


        public string Province { get; set; }
    }
}