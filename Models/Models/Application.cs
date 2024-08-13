using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineJobPortal.Models
{
    public class Application
    {

        [Key] 
        public int ApplicationID { get; set; }
        [ForeignKey("Job")]
        public int JobID { get; set; }
        [ForeignKey("Candidate")] 
        public int CID { get; set; }
        [Required] 
        public string Resume {  get; set; }
        [Required] 
        public string Skills { get; set; }
        public string Status { get; set; }
        public DateTime DateOfApplication { get; set; }
        //Navigation
        [NotMapped]
        [JsonIgnore]
        public Job Jobs { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Candidate candidates { get; set; }
    }
}
