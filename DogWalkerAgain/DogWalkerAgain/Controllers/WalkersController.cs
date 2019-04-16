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
            
            ApplicationDbContext context = new ApplicationDbContext();
            
            //ViewBag.map = APIKeys.APIKey;

            var incompleteWalks = context.Walks.Where(x => x.WalkComplete == false).ToList();
            
            return View(incompleteWalks);
        }

        //Search dogs
        public async Task<ActionResult> DogSearch(string searchString)
        {

            var dogs = from d in db.Dogs
                       select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchString));
            }

            return View(await dogs.ToListAsync());
        }


        // GET: Walkers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Walker walker = db.Walkers.Find(id);
            if (walker == null)
            {
                return HttpNotFound();
            }
            return View(walker);
        }

        // GET: Walkers/Create
        public ActionResult Create()
        {
            Walker walker = new Walker();
            return View(walker);
        }

        // POST: Walkers/Create
        [HttpPost]
        public ActionResult Create(Walker walker)
        {
            try
            {
                db.Walkers.Add(walker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
