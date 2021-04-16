using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheReview
{
    public class EditReview
    {
        public int ReviewId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Review")]
        public string Content { get; set; }

        public bool HuntRating { get; set; }

        //public int? HuntId { get; set; }
        //public virtual Hunt Hunt { get; set; }

        public DateTimeOffset DateCreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
