using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class Hunt
    {
        [Key]
        public int HuntId { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Shop))]
        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }
        public DateTime DateofHunt { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

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

        public string City { get; set; }
        public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
