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
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var types = db.Companies.ToList();
                var codesList = new CompanyCodeViewModel
                {
                    codesForCompany = new CompanyCode(),
                    companiesCodeView = types
                };

                return View("SaveRecord", codesList);
            }
        }

        [HttpPost]
        public ActionResult SaveRecord(CompanyCodeViewModel code)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                bool codeExists = false;
                DbContentPSI db = new DbContentPSI();
                var codes = db.Codes;

                foreach (var c in codes)
                {
                    if (c.Code == code.codesForCompany.Code)
                    {
                        codeExists = true;
                        break;
                    }
                }

                if (!codeExists)
                {
                    CompanyCode userCode = new CompanyCode();

                    userCode.Code = code.codesForCompany.Code;
                    userCode.CompanyId = code.codesForCompany.CompanyId;
                    userCode.Name = code.codesForCompany.Name;
                    userCode.Points = code.codesForCompany.Points;
                    db.Codes.Add(userCode);
                    db.SaveChanges();
                    ViewBag.Msg = "Succeded";
                    ViewBag.ResultMessage = "Code was successfully added.";
                    return View("Result");
                }
                else
                {
                    ViewBag.Msg = "Exact code already exists.";
                    ViewBag.ResultMessage = "Exact code already exists. Please try again.";
                    return View("Result");
                }
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
                ListOfCompanyCodes vm = new ListOfCompanyCodes()
                {
                    codesForCompany = db.Codes.ToList(),
                    companiesCodeView = db.Companies.ToList()
                };

                return View(vm);
            }
        }

        public ActionResult Result(string message)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CodesUsage()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var companies = db.Companies;
                var companyCodes = db.Codes;
                List<UsageViewModel> model = new List<UsageViewModel>();

                foreach (var company in companies)
                {
                    foreach (var code in companyCodes)
                    {
                        if (company.Id == code.CompanyId)
                        {
                            var item = new UsageViewModel();
                            item.CompaniesList = db.Companies.ToList();
                            item.CodeName = code.Name;
                            item.CompanyName = company.Name;
                            item.TimesUsed = code.TimesUsed;
                            model.Add(item);
                        }
                    }
                }

                return View(model);
            }
        }
    }
}