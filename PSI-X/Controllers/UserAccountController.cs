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
        private DbContentPSI db = new DbContentPSI();
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

                ViewBag.Registered = 1;
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
                return View("Home");
            }
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Username == null || user.Password == null)
            {
                ModelState.AddModelError("", "Please fill both fields.");
            }

            else
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
                        return View("Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or password is not valid.");
                    }

                }
            }

            return View();
        }

        public ActionResult Home()
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
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult LogOut(User user)
        {
            FormsAuthentication.SignOut();
            Session["Id"] = null;
            Session["Username"] = null;
            return RedirectToAction("Login");
        }
    }
}