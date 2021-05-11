using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheDress
{
    public class CreateDress
    {
        [Required]
        [MinLength(2, ErrorMessage = "The name should be at least 2 characters long")]
        [MaxLength(15, ErrorMessage = "There are too many characters in this field")]
        [Display(Name = "Dress Size")]
        public string DressSize { get; set; }
    }
}
