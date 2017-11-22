using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSI_X.ViewModels;
using PSI_X.Models;
using System.Collections;

namespace PSI_X.Controllers
{
   // [Authorize]
    public class UserPointsController : Controller
    {
        // GET: UserPoints
        private DbContentPSI db = new DbContentPSI();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPoints()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPoints(CodeViewModel code)
        {
            ViewBag.Message = "";
            CompanyCode userCode = null;
            IEnumerable<CompanyCode> list = db.Codes.ToList();
            foreach(var kodas in list)
            {
                if (code.CodeG == kodas.Code)
                {
                    userCode = kodas; // Did find the code in db
                    break;
                }
            }

            if (userCode != null)
            { 
                int UserId1 = 0;
                string k = Session["Id"].ToString();
                UserId1 = int.Parse(k);
                UserId1 = Convert.ToInt32(k);

                var company = db.Companies
                                .Where(c => c.Id == userCode.CompanyId)
                                .FirstOrDefault();

                var ifHasCompany = db.UserPoints.FirstOrDefault(m => m.UserId == UserId1
                && m.CompanyId == userCode.CompanyId);

                if (ifHasCompany == null)
                {
                    UserPoints points = new UserPoints()
                    {
                        CompanyId = userCode.CompanyId,
                        UserId = UserId1,
                        UserCompanyPoints = userCode.Points
                    };
                    userCode.TimesUsed++;
                    db.Codes.Attach(userCode);
                    var entry = db.Entry(userCode);
                    entry.Property(p => p.TimesUsed).IsModified = true;
                    db.UserPoints.Add(points);
                    db.SaveChanges();
                    ViewBag.Message = string.Format("You just got the {0} points in {1}!", userCode.Points, company.Name);
                    ModelState.Clear();
                }
                else
                {
                    ifHasCompany.UserCompanyPoints += userCode.Points;
                    db.SaveChanges();
                    ViewBag.Message = string.Format("You just got the {0} points in {1}!", userCode.Points, company.Name);
                }
            }
            else
            {
                ViewBag.Message = "The code is not valid!";
                return View();
            }
           
            return View();
        }
    }
}