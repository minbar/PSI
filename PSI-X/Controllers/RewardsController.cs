using PSI_X.ViewModels;
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
        public ActionResult AllRewards()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var companies = database.Companies;
                var rewards = database.Rewards;
                List<RewardsViewModel> model = new List<RewardsViewModel>();

                foreach (var company in companies)
                {
                    foreach (var reward in rewards)
                    {
                        if (company.Id == reward.CompanyId)
                        {
                            var item = new RewardsViewModel();
                            item.CompanyName = company.Name;
                            item.RewardName = reward.RewardName;
                            item.RequiredPoints = reward.RequiredPoints;
                            model.Add(item);
                        }
                    }
                }

                return View(model);
            }
        }

        public ActionResult NewReward()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var model = new RewardAddViewModel();
                model.companies = database.Companies;
                model.reward = new Rewards();

                return View("SaveReward", model);
            }
        }

        [HttpPost]
        public ActionResult SaveReward(RewardAddViewModel model)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                database.Rewards.Add(model.reward);
                database.SaveChanges();

                ViewBag.Message = "New reward was successfully added.";
                return View("Result");
            }
        }

        public ActionResult Index()
        {
            int usrId = int.Parse(Session["Id"].ToString());
            IEnumerable<UserPoints> userPointsList = database.UserPoints.ToList();
            IEnumerable<Rewards> rewards = database.Rewards.ToList();
            List<Company> companies = database.Companies.ToList();
            List<UserRewardsViewModel> rewardsList = new List<UserRewardsViewModel>();
            foreach (var record in userPointsList)
            {
                if(record.UserId == usrId)
                {
                    foreach (var reward in rewards)
                    {
                        if (record.UserCompanyPoints >= reward.RequiredPoints 
                            && record.CompanyId == reward.CompanyId)
                        {
                            foreach (var company in companies)
                            {
                                if (company.Id == reward.CompanyId)
                                {
                                    rewardsList.Add(new UserRewardsViewModel
                                    {
                                        companyName = company.Name,
                                        rewardName = reward.RewardName
                                    });
                                }
                            }
                        }
                    }
                }
            }

            return View(rewardsList);
        }
    }
}