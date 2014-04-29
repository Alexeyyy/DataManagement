using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class SectionsController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult SectionsPage()
        {
            return View(db.Sections.ToList());
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return View("SectionsPage", db.Sections.ToList());
            }

            List<Section> sections = db.Sections.Where(n => (n.Title.Contains(searchString) || n.Description.Contains(searchString) || n.Ecologist.Name.Contains(searchString) || n.Ecologist.Surname.Contains(searchString) || n.Ecologist.FatherName.Contains(searchString))).ToList();

            return View("SectionsPage", sections);
        }

    }
}
