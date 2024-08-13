using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineJobPortal.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }

        [Required]
        [MaxLength(100)]
        public string StateName { get; set; }

        //add foreign key
        [Required]
        public int CountryID { get; set; }

        // Navigation Property
        [JsonIgnore]
        public Country Country { get; set; }

        [JsonIgnore]
        public List<City> Cities { get; set; }
    }
}
