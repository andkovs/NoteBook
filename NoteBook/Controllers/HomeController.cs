﻿using NoteBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteBook.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
			//db.Database.Delete();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
