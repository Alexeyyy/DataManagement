using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Запрос(поиск) по сущностям "Эколог" и "Секция"
        [HttpGet]
        public ActionResult SearchSection(string searchString, string ecologistName)
        {
            if (string.IsNullOrWhiteSpace(searchString) && string.IsNullOrWhiteSpace(ecologistName))
            {
                return View("SectionsPage", db.Sections.ToList());
            }

            int lessonsCount;
            int freeSpots;
            DateTime date;

            Int32.TryParse(searchString, out lessonsCount);
            Int32.TryParse(searchString, out freeSpots);
            DateTime.TryParse(searchString, out date);
            

            List<Section> sections = db.Ecologists.Where(e => (e.Surname.Contains(ecologistName) ||e.Name.Contains(ecologistName) || e.FatherName.Contains(ecologistName)))
                                                  .SelectMany(e => db.Sections.Where(s => (s.Ecologist == e && (s.Title.Contains(searchString) || s.Description.Contains(searchString) 
                                                                                            || s.FreeSpotsCount == freeSpots || s.LessonsCount == lessonsCount 
                                                                                            || (s.StartLessonsTime.Year == date.Year && s.StartLessonsTime.Month == date.Month && s.StartLessonsTime.Day == date.Day)))))
                                                  .ToList();
            /*
                       
            List<Section> sections = db.Sections.Where(n => (n.Title.Contains(searchString) || n.Description.Contains(searchString) 
                                                        || n.Ecologist.Name.Contains(searchString) || n.Ecologist.Surname.Contains(searchString) 
                                                        || n.Ecologist.FatherName.Contains(searchString) || n.LessonsCount == lessonsCount
                                                        || n.FreeSpotsCount == freeSpots || (n.StartLessonsTime.Year == d.Year && n.StartLessonsTime.Month == d.Month && n.StartLessonsTime.Day == d.Day))).ToList();*/
            
            return View("SectionsPage", sections);
        }
    }
}
