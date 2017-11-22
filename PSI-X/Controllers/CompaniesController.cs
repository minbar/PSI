using PSI_X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSI_X.ViewModels;
using System.Collections;

namespace PSI_X.Controllers
{
   //[Authorize]
    public class CompaniesController : Controller
    {
        private DbContentPSI db = new DbContentPSI();
        // GET: Companies
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(CompanyViewModel company)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                /*without validations yet */
                ViewBag.RespondMsg = "";
                Company newCompany = new Company();
                if (ModelState.IsValid)
                {
                    newCompany.Address = company.Address;
                    newCompany.TypeOfCompany = company.TypeOfCompany;
                    newCompany.Name = company.Name;
                    db.Companies.Add(newCompany);
                    db.SaveChanges();
                    ViewBag.RespondMsg = "Succeeded";
                    ModelState.Clear();
                }
                return View();
            }
        }
        public ActionResult Show()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                IEnumerable<Company> comp = db.Companies.ToList();
                return View(comp);
            }
            
        }
    }
}