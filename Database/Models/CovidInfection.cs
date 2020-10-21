using System.ComponentModel.DataAnnotations;

namespace skolu_nepobiram.Database.Models
{
    public class CovidInfection
    {
        [Key] public int Id { get; set; }

        public string Povince { get; set; }
        public string ProvinceLau { get; set; }

        public int Infected { get; set; }
        public int Recovered { get; set; }
        public int Died { get; set; }
    }
}