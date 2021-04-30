using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}