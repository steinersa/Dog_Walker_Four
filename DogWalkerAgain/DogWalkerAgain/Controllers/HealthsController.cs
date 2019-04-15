using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class HealthsController : Controller
    {
        // GET: Healths
        public ActionResult Index()
        {
            return View();
        }

        // GET: Healths/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Healths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Healths/Create
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

        // GET: Healths/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Healths/Edit/5
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

        // GET: Healths/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Healths/Delete/5
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
