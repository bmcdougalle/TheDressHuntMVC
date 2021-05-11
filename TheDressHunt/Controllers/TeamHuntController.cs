using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheDressHunt.Models.TheTeamHunt;
using TheDressHunt.Service;

namespace TheDressHunt.Controllers
{
    public class TeamHuntController : Controller
    {
        // GET: TeamHunt
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamHuntService(userId);
            var model = service.GetTeamHunts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTeamHunt model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateTeamHuntSrv();
            if (service.CreateTeamHunt(model))
            {
                TempData["SaveResult"] = "Your Team was created";
                return RedirectToAction("");
            }

            ModelState.AddModelError("", "Failed to create");
            return View(model);

        }

        public ActionResult Detail(int id)
        {
            var service = CreateTeamHuntSrv();
            var model = service.GetTeamHUntById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTeamHuntSrv();
            var Detail = service.GetTeamHUntById(id);
            var model =
                new EditTeamHunt
                {
                    TeamName = Detail.TeamName
                };

            return View(model);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditTeamHunt model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.TeamId != id)
            {
                ModelState.AddModelError("", "Could not find Team");
                return View(model);
            }

            var service = CreateTeamHuntSrv();
            if (service.UpdateTeamHunt(model))
            {
                TempData["SaveResult"] = "Your team was Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could Not Update");
            return View();
        }



        public ActionResult Delete(int id)
        {
            var service = CreateTeamHuntSrv();
            var model = service.GetTeamHUntById(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeam (int id)
        {
            var service = CreateTeamHuntSrv();
            service.DeleteTeamHunt(id);
            TempData["SaveResult"] = "Your Team was removed";
            return RedirectToAction("Index");
        }


        private TeamHuntService CreateTeamHuntSrv()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamHuntService(userId);
            return service;
        }
    }
}