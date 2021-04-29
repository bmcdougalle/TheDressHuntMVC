using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

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
        public string HoursOfOperation { get; set; }

        public string TypeOfOccasion { get; set; }

        //public bool IsPlusSizeFriendly { get; set; }

        [Required]
        [Display(Name = "Available Dress sizes")]
        public List<Dress> DressSizes { get; set; } = new List<Dress>();

        [ForeignKey(nameof(Dress))]
        public int DressId { get; set; }

        public virtual Dress Dress { get; set; }

    }
}
