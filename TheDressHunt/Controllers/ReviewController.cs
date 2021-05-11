using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheDressHunt.Models.TheReview;
using TheDressHunt.Service;

namespace TheDressHunt.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReview model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateReviewSrv();
            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your Review was posted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not Post");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var service = CreateReviewSrv();
            var model = service.GetReviewById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateReviewSrv();
            var Detail = service.GetReviewById(id);
            var model =
                new EditReview
                {
                    Title = Detail.Title,
                    Content = Detail.Content,
                    DateCreatedUTC = Detail.DateCreatedUTC,
                    HuntRating = Detail.HuntRating
                };

            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditReview model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.ReviewId != id)
            {
                ModelState.AddModelError("", "Review Doesn't exist");
                return View(model);
            }

            var service = CreateReviewSrv();
            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your Review was Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could Not Update");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var service = CreateReviewSrv();
            var model = service.GetReviewById(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReview (int id)
        {
            var service = CreateReviewSrv();
            service.DeleteReview(id);
            TempData["SaveResult"] = "Your Review was removed";
            return RedirectToAction("Index");
        }



        private ReviewService CreateReviewSrv()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }
    }
}