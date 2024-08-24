using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortalMVC.Models
{
    public class City
    {
        public int CityID { get; set; }
        [DisplayName("City Name")]
        public string CityName { get; set; }
        public int StateID { get; set; }
    }
}
