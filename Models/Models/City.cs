using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineJobPortal.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        //foregin key add to state table
        public int StateID { get; set; }

        // Navigation Property
        [JsonIgnore]
        public State State { get; set; }
        [JsonIgnore]
        public List<Candidate> Candidates { get; set; }
        [JsonIgnore]
        public List<Recruiter> Recruiters { get; set; }
        [JsonIgnore]
        public List<Application> Applications { get; set; }
    }
}
