using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;

namespace TheDressHunt.Models.TheShop
{
    public class CreateShop
    {
        [Required]
        [Display(Name = "Shop Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Too many characters in this field")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Location")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(200, ErrorMessage = "Too many characters in this field")]
        public string Location { get; set; }

        [Required]
        public string HoursOfOepration { get; set; }

        public int DressId { get; set; }

        public virtual Dress Dress { get; set; }
        public List<Dress> DressSizes { get; set; } = new List<Dress>();
    }
}
