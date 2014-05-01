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
        public ActionResult EcologistsPage(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString)) {
                return View("EcologistsPage", db.Ecologists);
            }
                     
            return View("EcologistsPage", db.Ecologists.Where(n => (n.Name.Contains(searchString) || n.Surname.Contains(searchString) 
                        || n.InterestsSphere.Contains(searchString) || n.FatherName.Contains(searchString)
                        || n.DistrictLocation.Contains(searchString) || n.Education.Contains(searchString) || n.Email.Contains(searchString))));
        }

        public ActionResult Delete(int id)
        {
            Ecologist e = db.Ecologists.Find(id);
            
            if (e != null)
            {
                try
                {
                    db.Ecologists.Remove(e);
                    db.SaveChanges();
                }
                catch { }
            }

            return RedirectToAction("EcologistsPage");
        }

        
        public ActionResult Edit(int id)
        {
            return View(db.Ecologists.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Ecologist e)
        {
            Ecologist ecologist = db.Ecologists.Find(e.ID);
            TryUpdateModel<Ecologist>(ecologist, new string[] { "InterestsSphere" , "Name" });

            db.Entry<Ecologist>(ecologist).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("EcologistsPage");
        }
    }
}
