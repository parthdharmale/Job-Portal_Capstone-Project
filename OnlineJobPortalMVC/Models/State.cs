using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortalMVC.Models
{
    public class State
    {
        public int StateID { get; set; }
        [DisplayName("State Name")]
        public string StateName { get; set; }
        public int CountryID { get; set; }
    }
}
