using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class TeamHunt
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Too many characters in this field")]
        public string TeamName { get; set; }
        public DateTime DateOfHunt { get; set; }

        [ForeignKey(nameof(Hunt))]
        public int HuntId { get; set; }
        public virtual Hunt Hunt { get; set; }
    }
}
