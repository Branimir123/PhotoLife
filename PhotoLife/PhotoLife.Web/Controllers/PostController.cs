﻿using System.Web.Mvc;

namespace PhotoLife.Controllers
{
    public class PostController : Controller
    {
        // Get: All
        public ActionResult All()
        {
            return View();
        }

        // Post: Add
        [Authorize]
        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }
    }
}