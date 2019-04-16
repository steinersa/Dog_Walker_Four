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
    public class OwnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Owners
        public ActionResult Index()
        {
            var userResult = User.Identity.GetUserId();
            var currentOwner = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            var walkList = db.Walks.Where(x => currentOwner.Id == x.OwnerId).ToList();
            return View(walkList);
        }

        // GET: Owners/Details/5
        public ActionResult Details()
        {
            var currentPerson = User.Identity.GetUserId();
            var currentUser = db.Owners.Where(x => currentPerson == x.ApplicationId).FirstOrDefault();
            return View(currentUser);
        }

        //var userResult = User.Identity.GetUserId();
        //var currentUser = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
        //dog.OwnerId = currentUser.Id;



        // GET: Owners/Create
        public ActionResult Create()
        {
            Owner owner = new Owner();
            return View(owner);
        }

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip")] Owner owner)
        {
            owner.ApplicationId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Owners.Add(owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            var ownerIs = db.Owners.Where(w => w.Id == id).FirstOrDefault();
            return View(ownerIs);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        public ActionResult Edit(Owner owner)
        {
            try
            {
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int id)
        {
            var ownerIs = db.Owners.Where(w => w.Id == id).FirstOrDefault();
            return View(ownerIs);
        }

        // POST: Owners/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var DeleteOwner = db.Owners.Where(w => w.Id == id).FirstOrDefault();
                db.Owners.Remove(DeleteOwner);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Filter(string choice)
        {
            return View();
        }
    }
}
