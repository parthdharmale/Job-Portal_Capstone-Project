using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineJobPortal.Models
{
    public class Job
    {
        [Key] public int JobID { get; set; }

        //public Recruiter Recruiter { get; set; }

        //[ForeignKey("Recruiter")]
        public int RID { get; set; }
        public int CityID { get; set; }
        public string Location {  get; set; }
        public string Description { get; set; }
        [Required] public string Skills { get; set; }
        public string RecruiterName { get; set; }

        [Phone]
        public string RecruiterContact { get; set; }

        [EmailAddress]
        public string RecruiterEmail { get; set; }
        public DateTime JobPostDate { get; set; }
        [Required] public DateTime JobExpireDate { get; set; }
        public string ModeOfWork { get; set; }
        [JsonIgnore]
        public List<Application> Applications { get; set; }

    }
}
