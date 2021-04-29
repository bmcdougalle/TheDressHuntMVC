using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;

namespace TheDressHunt.Models.TheShop
{
    public class ShopDetail
    {
        public int ShopId { get; set; }

        [Display(Name = "Shop Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Hours Of Operation")]
        public string HoursOfOperation { get; set; }

        [Display(Name = "Occasion")]
        public string TypeOfOccasion { get; set; }

        public ICollection<Dress> DressSize { get; set; }
    }
}
