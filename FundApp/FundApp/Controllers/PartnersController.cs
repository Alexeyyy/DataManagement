using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class PartnersController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult PartnersPage()
        {
            return View(db.Partners.ToList());
        }

        [HttpGet]
        public ActionResult SearchPartner(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return View("PartnersPage", db.Partners.ToList());
            
            List<Partner> partners = db.Partners.Where(n => (n.Name.Contains(searchString) || n.Surname.Contains(searchString) || n.FatherName.Contains(searchString) || n.CompanyName.Contains(searchString) || n.Address.Contains(searchString) || n.Email.Contains(searchString) || n.Description.Contains(searchString))).ToList();

            return View("PartnersPage", partners);
        }
    }
}
