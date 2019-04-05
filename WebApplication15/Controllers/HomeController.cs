using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthDemo.Data;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new HomePageViewModel
            {
                IsAuthenticated = User.Identity.IsAuthenticated
            };

            if (User.Identity.IsAuthenticated)
            {
                var db = new AuthDb(Properties.Settings.Default.ConStr);
                var user = db.GetByEmail(User.Identity.Name);
                vm.Name = user.Name;
            }

            return View(vm);
        }

        [Authorize]
        public ActionResult Secret()
        {
            return View();
        }
    }
}