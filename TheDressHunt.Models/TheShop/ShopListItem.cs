using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Models.TheDress;

namespace TheDressHunt.Models.TheShop
{
    public class ShopListItem
    {
        public int ShopId { get; set; }

        [Display(Name = "Shop Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Hours Of Operation")]
        public string HoursOfOperation { get; set; }

        public int? DressId { get; set; }

        [Display(Name = "Available Dress Sizes")]
        public List<DressListItem> DressSizes { get; set; } = new List<DressListItem>();
    }
}
