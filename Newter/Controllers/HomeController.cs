﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newter.Models;
using PagedList;
using PagedList.Mvc;

namespace Newter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (searchBy == "Post")
            {
                return View(db.Newts.Where(x=>x.TextBody.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 6));
            }
            else
            {   
                return View(db.Newts.Where(x => x.Author.Handle.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 6));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnFollow()
        {
            throw new NotImplementedException();
        }


        public ActionResult Profile()
        {
            throw new NotImplementedException();
        }

        // GET: Sweets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sweets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string text)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);
            var newt = new Newt()
            {
                Author = user,
                TextBody = text,
                DateCreated = DateTime.Now
            };
            db.Newts.Add(newt);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}