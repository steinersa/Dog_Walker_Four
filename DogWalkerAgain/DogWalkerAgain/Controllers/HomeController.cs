﻿using DogWalkerAgain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            string role = db.Users.Where(x => id == x.Id).Select(x => x.UserRole).SingleOrDefault();
            if (role == "Owner")
            {
                return RedirectToAction("Index", "Owners");
            }
            else if (role == "Walker")
            {
                return RedirectToAction("Index", "Walkers");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}