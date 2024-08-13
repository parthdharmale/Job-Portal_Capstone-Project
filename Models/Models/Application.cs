using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Models
{
    public class Application
    {

        [Key] 
        public int ApplicationID { get; set; }
        public int JobID { get; set; }
        public int CID { get; set; }
        [Required] 
        public string Resume {  get; set; }
        [Required] 
        public string Skills { get; set; }
        public string Status { get; set; }
        public DateTime DateOfApplication { get; set; }
    }
}
