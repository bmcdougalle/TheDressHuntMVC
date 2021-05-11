using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheDressHunt.Models.TheShop;
using TheDressHunt.Service;

namespace TheDressHunt.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShopService(userId);
            var model = service.GetShops();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateShop model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateShopService();
            if (service.CreateShop(model))
            {
                TempData["SaveResult"] = "This shop was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Shop could not be create");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var service = CreateShopService();
            var model = service.GetShopById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShopService();
            var detail = service.GetShopById(id);
            var model =
                new EditShop
                {
                    Name = detail.Name,
                    Location = detail.Location,
                    HoursOfOperation = detail.HoursOfOperation,
                    DressId = detail.DressId,
                    DressSizeAvailable = (List<Data.Dress>)detail.DressSize,


                };
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditShop model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.ShopId != id)
            {
                ModelState.AddModelError("", "Shop doesn't exist");
                return View(model);
            }

            var service = CreateShopService();

            if (service.UpdateShop(model))
            {
                TempData["SaveResult"] = "THe shop was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Update Failed");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateShopService();
            var model = service.GetShopById(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShop(int id)
        {
            var service = CreateShopService();
            service.DeleteShop(id);
            TempData["SaveResult"] = "This Shop was removed";
            return RedirectToAction("Index");
        }


        private ShopService CreateShopService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShopService(userId);
            return service;
        }
    }
}