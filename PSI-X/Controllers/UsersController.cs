﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSI_X.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}