using DogWalkerAgain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            Walk walk = db.Walks.Where(s => s.Id.Equals(id)).FirstOrDefault();
            return View(walk);
        }

        // GET: Walks/Create
        public ActionResult Create()
        {
            Walk walk = new Walk();
            return View(walk);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WalkerApprovalStatus,OwnerApprovalStatus,WalkCompleted,OwnerId,WalkerId")] Walk walk)
        {
            var userResult = User.Identity.GetUserId();
            var currentUser = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            walk.OwnerId = currentUser.Id;
            if (ModelState.IsValid)
            {
                db.Walks.Add(walk);
                db.SaveChanges();
                return RedirectToAction("Create", "WalkDetails");
            }

            return View(walk);
        }

        // GET: Walks/Edit/5
        public ActionResult Edit(int id)
        {
            var walk = db.Walks.Where(x => x.Id == id).FirstOrDefault();
            return View(walk);
        }

        // POST: Walks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,WalkId,WalkerApprovalStatus,OwnerApprovalStatus,WalkCompleted")] Walk walk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Owners");
            }
            return View(walk);
        }

        // GET: Walks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walk walk = db.Walks.Find(id);
            if (walk == null)
            {
                return HttpNotFound();
            }
            return View(walk);
        }

        // POST: Walks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Walk walk = db.Walks.Find(id);
            db.Walks.Remove(walk);
            db.SaveChanges();
            return RedirectToAction("Index", "Owners");
        }
    }
}
