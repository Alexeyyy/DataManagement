using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class RoomUserController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult UserRoom()
        {
            return View();
        }

        #region Жалоба
        
        [HttpGet]
        public ActionResult Complaint()
        {
            return View();    
        }

        [HttpPost]
        public ActionResult Complaint(Complaint complaint)
        {
            if (complaint != null)
            {
                complaint.Creator = db.Users.Find(Session["SystemUserID"]);
                db.Complaints.Add(complaint);
                db.SaveChanges();
            }
            return RedirectToAction("UserRoom");
        }

        #endregion

        #region Курсы

        public ActionResult Sections()
        {
            List<Section> sections = db.Sections.ToList();
            return View(sections);
        }

        //регистрация на курсы
        
        #endregion
    }
}
