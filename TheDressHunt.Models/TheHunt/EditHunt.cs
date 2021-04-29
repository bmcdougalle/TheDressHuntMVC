using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheHunt
{
    public class EditHunt
    {
        public int HuntId { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public DateTime DateOfHunt { get; set; }

        public string City { get; set; }

        [Display(Name = "What's The Occasion?")]
        public string TypeOfOccasion { get; set; }

        [Display(Name = "Dress Type")]
        public string DressType { get; set; }


        [Display(Name = "Color Scheme")]
        public string ColorScheme { get; set; }

        public int ShopId { get; set; }


    }
}
