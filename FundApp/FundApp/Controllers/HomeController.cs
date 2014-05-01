using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class HomeController : Controller
    {
        FundContext context = new FundContext();
        
        public ActionResult Index()
        {
            foreach (var e in context.EcologicalProblems)
                Debug.WriteLine(e.ProblemID);

            Debug.WriteLine("================================");

            foreach (var a in context.Achivements)
                Debug.WriteLine(a.AchievementID);

            return View();
        }
    }
}
