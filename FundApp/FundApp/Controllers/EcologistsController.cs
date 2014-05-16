using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class EcologistsController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult EcologistsPage()
        {
            List<Ecologist> ecologists = db.Ecologists.ToList();
            
            return View(ecologists);
        }

        //Поиск по экологам
        [HttpGet]
        public ActionResult SearchEcologists(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString)) {
                return View("EcologistsPage", db.Ecologists);
            }
                     
            return View("EcologistsPage", db.Ecologists.Where(n => (n.Name.Contains(searchString) || n.Surname.Contains(searchString) 
                        || n.InterestsSphere.Contains(searchString) || n.FatherName.Contains(searchString)
                        || n.DistrictLocation.Contains(searchString) || n.Education.Contains(searchString) || n.Email.Contains(searchString) || n.EcologicalProblems.Any(p => p.Title.Contains(searchString)))).ToList());
        }
    }
}
