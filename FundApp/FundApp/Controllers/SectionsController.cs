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

        [HttpGet]
        public ActionResult SearchSection(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return View("SectionsPage", db.Sections.ToList());
            }
            
            int lessonsCount;
            int freeSpots;
            DateTime d;

            Int32.TryParse(searchString, out lessonsCount);
            Int32.TryParse(searchString, out freeSpots);
            DateTime.TryParse(searchString, out d);
                       
            List<Section> sections = db.Sections.Where(n => (n.Title.Contains(searchString) || n.Description.Contains(searchString) 
                                                        || n.Ecologist.Name.Contains(searchString) || n.Ecologist.Surname.Contains(searchString) 
                                                        || n.Ecologist.FatherName.Contains(searchString) || n.LessonsCount == lessonsCount
                                                        || n.FreeSpotsCount == freeSpots || (n.StartLessonsTime.Year == d.Year && n.StartLessonsTime.Month == d.Month && n.StartLessonsTime.Day == d.Day))).ToList();
            
            //2
            /*string query_section;
            string query_ecologist;
            List<Section> s = db.Sections.Where(n => n.Title.Contains(query_section) )  */

            return View("SectionsPage", sections);
        }
    }
}
