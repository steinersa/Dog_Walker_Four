using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class WalkersController : Controller
    {
        // GET: Walkers
        public ActionResult Index()
        {
            ViewBag.map = APIKeys.APIKey;
            return View();
        }

        // GET: Walkers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Walkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Walkers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Walkers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Walkers/Edit/5
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

        // GET: Walkers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Walkers/Delete/5
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
