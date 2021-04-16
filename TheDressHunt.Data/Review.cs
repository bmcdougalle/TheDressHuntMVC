using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters long")]
        [MaxLength(500, ErrorMessage = "Too many characters in this field")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Review")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters long")]
        [MaxLength(500, ErrorMessage = "Too many characters in this field")]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public bool HuntRating { get; set; }
    }
}
