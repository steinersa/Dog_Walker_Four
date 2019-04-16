using DogWalkerAgain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class DemeanorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Demeanors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Demeanors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demeanors/Create
        public ActionResult Create()
        {
            Demeanor demeanor = new Demeanor();
            return View(demeanor);
        }

        // POST: Demeanors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalFriendly,KidFriendly,Comments,DogId")] Demeanor demeanor)
        {
            var userResult = User.Identity.GetUserId();
            var currentUser = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            var currentDog = db.Dogs.Where(x => currentUser.Id == x.OwnerId).FirstOrDefault();
            demeanor.DogId = currentDog.Id;
            if (ModelState.IsValid)
            {
                db.Demeanor.Add(demeanor);
                db.SaveChanges();
                return RedirectToAction("Index", "Dogs");
            }

            return View(demeanor);
        }

        // GET: Demeanors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demeanors/Edit/5
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

        // GET: Demeanors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demeanors/Delete/5
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
