using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheDressHunt.Models.HuntCreate;
using TheDressHunt.Models.TheHunt;
using TheDressHunt.Service;

namespace TheDressHunt.Controllers
{
    public class HuntController : Controller
    {
        // GET: Hunt
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HuntService(userId);
            var model = service.GetHunts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateHunt model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateHuntSrv();
            if (service.CreateHunt(model))
            {
                TempData["SaveResult"] = "Your Hunt was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to create hunt");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var service = CreateHuntSrv();
            var model = service.GetHuntById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHuntSrv();
            var Detail = service.GetHuntById(id);
            var model =
                new EditHunt
                {
                    DateOfHunt = Detail.DateOfHunt,
                    TeamId = Detail.TeamId,
                    ColorScheme = Detail.ColorScheme,
                    City = Detail.City,
                    TypeOfOccasion = Detail.TypeOfOccasion,
                    DressType = Detail.DressType,
                    ShopId = Detail.ShopId,
                };
            return View(model);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditHunt model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.HuntId != id)
            {
                ModelState.AddModelError("", "Hunt Not Found");
                return View(model);
            }

            var service = CreateHuntSrv();
            if (service.UpdateHunt(model))
            {
                TempData["SaveResult"] = "Your Hunt was Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could Not Update");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var service = CreateHuntSrv();
            var model = service.GetHuntById(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHunt(int id)
        {
            var service = CreateHuntSrv();
            service.DeleteHunt(id);
            TempData["SaveResult"] = "Your Hunt was removed";
            return RedirectToAction("Index");
        }

        private HuntService CreateHuntSrv()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HuntService(userId);
            return service;
        }
    }
}