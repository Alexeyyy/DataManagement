using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class AchievementsController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult AchievementsPage()
        {
            return View(db.Achivements.ToList());
        }

        [HttpGet]
        public ActionResult AchievementsPage(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return View(db.Achivements.ToList());
            }

            List<Achievement> achievements = new List<Achievement>();
            
            if (Session["Role"] != null && Session["Role"].ToString() == "Administrator")
            {
                achievements = db.Achivements.Where(n => (n.Title.Contains(searchString) || n.Description.Contains(searchString) 
                                                    || n.EcologicalProblem.Title.Contains(searchString) || n.Administrator.Name.Contains(searchString)
                                                    || n.Administrator.Surname.Contains(searchString) || n.Administrator.FatherName.Contains(searchString))).ToList();
            }
            else
            {
                achievements = db.Achivements.Where(n => (n.Title.Contains(searchString) || n.Description.Contains(searchString)
                                                    || n.EcologicalProblem.Title.Contains(searchString))).ToList();
            }

            return View(achievements);
        }
    }
}
