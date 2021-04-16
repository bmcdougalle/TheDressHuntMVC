using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheHunt
{
    public class HuntDetail
    {
        [Display(Name = "What's The Occasion?")]
        public string TypeOfOccasion { get; set; }

        [Display(Name = "Dress Type")]
        public string DressType { get; set; }

       
        [Display(Name = "Color Scheme")]
        public string ColorScheme { get; set; }

    }
}
