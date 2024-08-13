using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Models
{
    public class Recruiter
    {
        [Key] public int RID {  get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public int CityID{ get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }

    }
}
