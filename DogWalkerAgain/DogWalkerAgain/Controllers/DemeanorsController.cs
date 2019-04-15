using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class DemeanorsController : Controller
    {
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
            return View();
        }

        // POST: Demeanors/Create
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
