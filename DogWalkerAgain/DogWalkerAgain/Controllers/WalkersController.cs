﻿using DogWalker
    ;
using DogWalkerAgain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DogWalker.Controllers
{
    public class WalkersController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Walkers
        public ActionResult Index()
        {
            
            var incompleteWalks = db.Walks.Where(x => x.WalkComplete == false).ToList();
            
            return View(incompleteWalks);
        }

        //Search dogs
        public ActionResult DogSearch(string dogBreed, string searchString)
        {
            var BreedList = new List<string>();

            //use LINQ to get list of dog breeds.
            IQueryable<string> BreedGet = from d in db.Dogs
                                          orderby d.Breed
                                          select d.Breed;

            BreedList.AddRange(BreedGet.Distinct());
            ViewBag.dogBreed = new SelectList(BreedList);

            var dogs = from d in db.Dogs
                       select d;


            if (!string.IsNullOrEmpty(searchString))
            {
                dogs = dogs.Where(d => d.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(dogBreed))
            {
                dogs = dogs.Where(d => d.Breed == dogBreed);
            }

            return View(dogs);
        }

        //GET: Details of dog picked
        public ActionResult DogDetails(int id)
        {

            var rate = new SelectList(new[]
            {
                new { ID = "1", Name = "1" },
                new { ID = "2", Name = "2" },
                new { ID = "3", Name = "3" },
                new { ID = "3", Name = "3" },
                new { ID = "3", Name = "3" },
            },
            "ID", "Name", 1);

            ViewData["rate"] = rate;

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }


        // GET: Walkers/Details/5
        public ActionResult Details()
        {
            var currentPerson = User.Identity.GetUserId();
            var currentUser = db.Walkers.Where(x => x.ApplicationId == currentPerson).FirstOrDefault();
            return View(currentUser);
        }

        // GET: Walkers/Create
        public ActionResult Create()
        {
            Walker walker = new Walker();
            return View(walker);
        }

        // POST: Walkers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Street,City,State,Zip,Rating")] Walker walker)
        {
            walker.ApplicationId = User.Identity.GetUserId();
            walker.Rating = 0;
            if (ModelState.IsValid)
            {
                db.Walkers.Add(walker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(walker);
        }

        // GET: Walkers/Edit/5
        public ActionResult Edit(int? id)
        {
            var walkerIs = db.Walkers.Where(w => w.Id == id).FirstOrDefault();
            return View(walkerIs);
        }

        // POST: Walkers/Edit/5
        [HttpPost]
        public ActionResult Edit(Walker walker)
        {
            try
            {
                db.Entry(walker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Walkers/Delete/5
        public ActionResult Delete(int id)
        {
            var walkerIs = db.Walkers.Where(w => w.Id == id).FirstOrDefault();
            return View(walkerIs);
        }

        // POST: Walkers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var DeleteWalker = db.Walkers.Where(w => w.Id == id).FirstOrDefault();
                db.Walkers.Remove(DeleteWalker);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult WalkOpportunities()
        {
            var walkOpportunities = db.Walks.Where(x => x.WalkComplete == false && x.OwnersApprovalStatus != "approved" && x.WalkerApprovalStatus != "interested").ToList();
            return View(walkOpportunities);
        }

        public ActionResult WalkSchedule()
        {
            List<WalkDetails> myDetails = new List<WalkDetails>();

            var userResult = User.Identity.GetUserId();
            var currentWalker = db.Walkers.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            var myWalks = db.Walks.Where(x => currentWalker.Id == x.WalkerId).ToList();
            foreach (Walk walk in myWalks)
            {
                var detailsOfSpecificWalk = db.WalkDetails.Where(x => walk.Id == x.WalkId && walk.OwnersApprovalStatus == "approved").SingleOrDefault();
                myDetails.Add(detailsOfSpecificWalk);
            }
            return View(myDetails);
        }

    }
}
