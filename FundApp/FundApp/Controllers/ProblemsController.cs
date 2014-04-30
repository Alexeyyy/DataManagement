using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class ProblemsController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult ProblemsPage()
        {
            List<EcologicalProblem> problems = db.EcologicalProblems.ToList();
           
            return View(problems);
        }

        [HttpGet]
        public ActionResult ProblemsPage(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return View(db.EcologicalProblems);
            }

            List<EcologicalProblem> requestedProblems = db.EcologicalProblems.Where(n => (n.Title.Contains(searchString) || n.Description.Contains(searchString))).ToList(); 
            
            return View(requestedProblems);
        }
        
    }
}
