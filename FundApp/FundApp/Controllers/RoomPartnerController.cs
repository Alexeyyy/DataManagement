using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class RoomPartnerController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult PartnerRoom()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Partner")
                return View();
            else
                return RedirectToAction("Http403", "Error");
        }

        //Создание жалобы
        [HttpGet]
        public ActionResult CreateComplaint()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Partner")
                return View();
            else
                return RedirectToAction("Http403", "Error");
        }

        [HttpPost]
        public ActionResult CreateComplaint(Complaint complaint)
        {
            if (complaint != null)
            {
                complaint.Creator = db.Users.Find(Session["SystemUserID"]);
                db.Complaints.Add(complaint);
                db.SaveChanges();
            }
            return RedirectToAction("PartnerRoom");
        }

    }
}
