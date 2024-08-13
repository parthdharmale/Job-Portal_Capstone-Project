using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineJobPortal.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        [Required]
        [MaxLength(100)]
        public string CountryName { get; set; }
        [JsonIgnore]
        public List<State> States { get; set; }
        [JsonIgnore]
        public List<Candidate> Candidates { get; set; }
        //public List<Recruiter> Recruiters { get; set; }

    }
}
