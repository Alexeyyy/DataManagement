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
        FundContext db = new FundContext();
        
        public ActionResult Index()
        {
            
            /*foreach (Council c in db.Councils.ToList())
            {
                Debug.WriteLine(c.Ecologists.Count);
            }

            int i = 0;
             */

            return View();
        }
    }
}
