using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSI_X.Models;
namespace PSI_X.Controllers
{
    public class RewardsController : Controller
    {
        DbContentPSI database = new DbContentPSI();
        // GET: Rewards
        public ActionResult Index()
        {
            int usrId = int.Parse(Session["Id"].ToString());
            IEnumerable<UserPoints> userPointsList = database.UserPoints.ToList();
            IEnumerable<Rewards> rewards = database.Rewards.ToList();
            List<string> rewardsList = new List<string>();
            foreach (var record in userPointsList)
            {
                if(record.UserId == usrId)
                {
                    foreach (var reward in rewards)
                    {
                        if (record.UserCompanyPoints >= reward.RequiredPoints 
                            && record.CompanyId == reward.CompanyId)
                        {
                            rewardsList.Add(reward.RewardName);
                        }
                    }
                }
            }
            



            return View(rewardsList);
        }
    }
}