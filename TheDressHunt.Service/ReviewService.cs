using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;
using TheDressHunt.Models;
using TheDressHunt.Models.TheReview;

namespace TheDressHunt.Service
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(CreateReview model)
        {
            var entity =
                new Review()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    HuntRating = model.HuntRating,
                    CreatedUtc = model.CreatedUtc
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ReviewListItem
                        {
                            ReviewId = e.ReviewId,
                            Title = e.Title,
                            HuntRating = e.HuntRating,
                            CreatedUtc = e.CreatedUtc
                        }
                     );
                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == id && e.OwnerId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        Title = entity.Title,
                        Content = entity.Content,
                        HuntRating = entity.HuntRating,
                        DateCreatedUTC = entity.CreatedUtc,
                        ModifiedUTC = entity.ModifiedUtc

                    };
            }
        }

        public bool UpdateReview(EditReview model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.CreatedUtc = model.DateCreatedUTC;
                entity.ModifiedUtc = model.ModifiedUTC;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
