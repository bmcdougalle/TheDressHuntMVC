using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Models.TheShop;
using TheDressHunt.Models.TheTeamHunt;

namespace TheDressHunt.Models.TheHunt
{
    public class HuntDetail
    {
        public int HuntId { get; set; }

        public string City { get; set; }

        [Display(Name = "What's The Occasion?")]
        public string TypeOfOccasion { get; set; }

        [Display(Name = "Dress Type")]
        public string DressType { get; set; }

       
        [Display(Name = "Color Scheme")]
        public string ColorScheme { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTime DateOfHunt { get; set; }

        public int? ShopId { get; set; }

        public virtual ShopListItem Shop { get; set; }

        public int? TeamId { get; set; }
        public virtual TeamHuntListItem Team { get; set; }

    }
}
