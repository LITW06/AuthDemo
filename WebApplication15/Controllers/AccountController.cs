﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthDemo.Data;

namespace WebApplication15.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user, string password)
        {
            var db = new AuthDb(Properties.Settings.Default.ConStr);
            db.AddUser(user, password);
            return Redirect("/");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var db = new AuthDb(Properties.Settings.Default.ConStr);
            var user = db.Login(email, password);
            if (user == null)
            {
                TempData["message"] = "Invalid login attempt";
                return Redirect("/account/login");
            }

            FormsAuthentication.SetAuthCookie(email, true);
            return Redirect("/");
        }
    }
}