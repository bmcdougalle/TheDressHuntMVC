using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;

namespace TheDressHunt.Models.HuntCreate
{
    public class CreateHunt
    {
        [Required]
        [Display(Name = "What's The Occasion?")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Too many characters in this field")]
        public string TypeOfOccasion { get; set; }

        [Required]
        [Display(Name = "Dress Type")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Too many characters in this field")]
        public string DressType { get; set; }

        [Required]
        [Display(Name = "Color Scheme")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(40, ErrorMessage = "Too many characters in this field")]
        public string ColorScheme { get; set; }

        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
