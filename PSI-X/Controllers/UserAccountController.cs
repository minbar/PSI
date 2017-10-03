using PSI_X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PSI_X.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User account)
        {
            if (ModelState.IsValid)
            {
                using (DbContentPSI db = new DbContentPSI())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();

                ViewBag.Message = account.FirstName + " " + account.LastName + " Successfully registered.";
            }
            return View();
        }

        public ActionResult Login()
        {

            if (Session["Id"] == null)
            {
                return View();
            }
            else
            {
                return View("LoggedIn");
            }
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DbContentPSI db = new DbContentPSI())
            {
                User usr = null;
                try
                {
                    usr = db.UserAccount.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                }

                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Username"] = usr.Username.ToString();
                    FormsAuthentication.SetAuthCookie(usr.Username, false);
                    return View("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }

            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return View("NotLoggedIn");
            }
        }

        [HttpPost]
        public ActionResult LogOut(User user)
        {
            FormsAuthentication.SignOut();
            Session["Id"] = null;
            Session["Username"] = null;
            return View("Loggedout");
        }

        public ActionResult NotLoggedIn()
        {
            return View();
        }

    }
}