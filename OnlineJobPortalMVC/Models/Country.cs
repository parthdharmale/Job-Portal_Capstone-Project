using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortalMVC.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        [DisplayName("Country Name")]
        public string CountryName { get; set; }
    }
}
