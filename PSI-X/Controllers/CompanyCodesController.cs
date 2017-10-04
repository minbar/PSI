using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSI_X.Models;
using PSI_X.ViewModels;

namespace PSI_X.Controllers
{
    //[Authorize]
    public class CompanyCodesController : Controller
    {
        // GET: CompanyCodes
        private DbContentPSI db = new DbContentPSI();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostCode()
        {
            var types = db.Companies.ToList();
            var codesList = new CompanyCodeViewModel
            {
                codesForCompany = new CompanyCode(),
                companiesCodeView = types
            };

            return View("SaveRecord", codesList);
        }
        [HttpPost]
        public ActionResult SaveRecord(CompanyCodeViewModel code)
        {
            ViewBag.Msg = "";
            CompanyCode userCode = new CompanyCode();

            userCode.Code = code.codesForCompany.Code;
            userCode.CompanyId = code.codesForCompany.CompanyId;
            userCode.Name = code.codesForCompany.Name;
            userCode.Points = code.codesForCompany.Points;
            db.Codes.Add(userCode);
            db.SaveChanges();
            ViewBag.Msg = "Succeededd";
            // ModelState.Clear();


            return View();

        }
        public ActionResult Show()
        {
            ListOfCompanyCodes vm = new ListOfCompanyCodes()
            {
                codesForCompany = db.Codes.ToList(),
                companiesCodeView = db.Companies.ToList()
            };

            return View(vm);
         }
    }
}