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
            if (Session["Role"] != null && Session["Role"].ToString() == "User")
                return View();
            else
                return RedirectToAction("Http403", "Error");
        }

        #region Жалоба

        [HttpGet]
        public ActionResult Complaint()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "User")
                return View();
            else
                return RedirectToAction("Http403", "Error");
        }

        //создание и отправка жалобы
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
            if (Session["Role"] != null && Session["Role"].ToString() == "User")
            {
                List<Section> sections = db.Sections.ToList();
                ViewBag.participant = db.RankUsers.Find(Session["SystemUserID"]);

                return View(sections);
            }
            else
                return RedirectToAction("Http403", "Error");
        }

        //регистрация на курсы
        public ActionResult RegisterOnSection(int sectionID)
        {
            var section = db.Sections.Find(sectionID);

            //Если свободные местра еще есть
            if (section.FreeSpotsCount > 0)
            {
                var participant = db.RankUsers.Find(Session["SystemUserID"]);

                section.Participants.Add(participant);
                //section.CalculateParticipantsCount();
                //section.CalculateFreeSpots();
                TryUpdateModel<Section>(section);
                db.Entry<Section>(section).State = System.Data.EntityState.Modified;

                db.SaveChanges();
            }

            return RedirectToAction("Sections");
        }

        //дерегистрация
        public ActionResult DeregisterFromSection(int sectionID)
        {
            var section = db.Sections.Find(sectionID);
            var participant = db.RankUsers.Find(Session["SystemUserID"]);

            section.Participants.Remove(participant);
            //section.CalculateParticipantsCount();
            //section.CalculateFreeSpots();
            TryUpdateModel<Section>(section);
            db.Entry<Section>(section).State = System.Data.EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Sections");
        }

        #endregion
    }
}
