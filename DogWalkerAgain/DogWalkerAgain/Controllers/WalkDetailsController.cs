using DogWalkerAgain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class WalkDetailsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: WalkDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: WalkDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalkDetails/Create
        public ActionResult Create()
        {
            WalkDetails walkDetails = new WalkDetails();
            return View(walkDetails);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,Distance,NumberOfDogs,WalkId")] WalkDetails walkDetails)
        {
            var userResult = User.Identity.GetUserId();
            var currentUser = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            var currentWalk = db.Walks.Where(x => currentUser.Id == x.OwnerId).FirstOrDefault();
            walkDetails.WalkId = currentWalk.Id;
            if (ModelState.IsValid)
            {
                db.WalkDetails.Add(walkDetails);
                db.SaveChanges();
                return RedirectToAction("Index", "Owners");
            }
            return View(walkDetails);
        }

        // GET: WalkDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
