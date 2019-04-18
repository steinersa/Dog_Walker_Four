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
        //private object _context;

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



        // GET: Owners/Edit/ 
        public ActionResult Edit(int? id)
        {
            var ownerIs = db.Owners.Where(w => w.Id == id).FirstOrDefault();
            return View(ownerIs);

            //var currentPerson = User.Identity.GetUserId();
            //var currentUser = db.Owners.Where(x => currentPerson == x.ApplicationId).FirstOrDefault();
            //return View(currentUser);

        }

        // POST: Owners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, FirstName, LastName, Street, City, State, Zip, ApplicationId")] Owner owner)
        {
            
                if (ModelState.IsValid)
                {
                    db.Entry(owner).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(owner);
            
        }
        //{
        //    var ownerInDB = db.Owners.Single(m => m.Id == owner.Id);
        //    ownerInDB.FirstName = owner.FirstName;
        //    ownerInDB.LastName = owner.LastName;
        //    ownerInDB.Street = owner.Street;
        //    ownerInDB.City = owner.City;
        //    ownerInDB.State = owner.State;
        //    ownerInDB.Zip = owner.Zip;
        //    //ownerInDB.Id = owner.Id;
        //    ownerInDB.Owners = db.Owners.ToList();
        //    db.SaveChanges();
        //    return View(owner);
        //}
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(owner).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(owner);
        //}

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
