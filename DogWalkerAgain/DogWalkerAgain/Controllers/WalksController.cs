using DogWalkerAgain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class WalksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Walks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Walks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            Walk walk = new Walk();
            return View(walk);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WalkerApprovalStatus,OwnerApprovalStatus,WalkCompleted,OwnerId,WalkerId")] Walk walk)
        {
            var userResult = User.Identity.GetUserId();
            var currentUser = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            walk.OwnerId = currentUser.Id;
            if (ModelState.IsValid)
            {
                db.Walks.Add(walk);
                db.SaveChanges();
                return RedirectToAction("Index", "Owners");
            }

            return View(walk);
        }

        // GET: Walks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Walks/Edit/5
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

        // GET: Walks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Walks/Delete/5
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
