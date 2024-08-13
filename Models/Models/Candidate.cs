using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineJobPortal.Models
{
    public class Candidate
    {
        [Key]
        public int CID { get; set; }
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }
        [Required]
        [ForeignKey("City")]
        public int CityID { get; set; }
        [Required]
        [ForeignKey("State")]
        public int StateID { get; set; }
        [Required]
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public string Education1 { get; set; }
        public float EducationResult1 { get; set; }
        public string EducationPassoutYear1 { get; set; }
        public string Education2 { get; set; }
        public float EducationResult2 { get; set; }
        public string EducationPassoutYear2 { get; set; }
        public string Education3 { get; set; }
        public float EducationResult3 { get; set; }
        public string EducationPassoutYear3 { get; set; }
        public string Workex1 { get; set; }
        public string WorkexDesc1 { get; set; }
        public string Workex2 { get; set; }
        public string WorkexDesc2 { get; set; }
        public string Workex3 { get; set; }
        public string WorkexDesc3 { get; set; }
        [JsonIgnore]
        public City City { get; set; }
        [JsonIgnore]
        public State State { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore]
        public List<Application> Applications { get; set; }
    }
}
