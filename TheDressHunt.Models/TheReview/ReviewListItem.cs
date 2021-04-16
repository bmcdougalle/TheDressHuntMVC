using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheReview
{
    class ReviewListItem
    {
        public int ReviewId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Rating")]
        public bool HuntRating { get; set; }

    }
}
