using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;
using System.Diagnostics;

namespace FundApp.Controllers
{
    public class RoomEcologistController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult EcologistRoom()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Ecologist")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        #region Жалобы пользователей

        public ActionResult Complaints()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Ecologist")
            {
                List<Complaint> complaints = db.Complaints.Where(n => n.IsHidden == false).ToList(); //вернем только те жалобы, которым еще не были рассмотрены 
                return View(complaints);
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        //Создание проблемы на базе жалобы
        [HttpGet]
        public ActionResult CreateProblem(int complaintID)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Ecologist")
            {
                ViewBag.complaintID = complaintID;
                return View();
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        [HttpPost]
        public ActionResult CreateProblem(EcologicalProblem problem, int complaintID)
        {
            //Debug.WriteLine(complaintID);
            try
            {
                //одновременно "отклоняем" жалобу
                var complaint = db.Complaints.Find(complaintID);
                complaint.IsHidden = true;
                TryUpdateModel<Complaint>(complaint);
                db.Entry<Complaint>(complaint).State = System.Data.EntityState.Modified;
                db.SaveChanges();

                //сохраняем проблему
                problem.Creator = db.Ecologists.Find(Session["SystemUserID"]);
                problem.Complaint = db.Complaints.Find(complaintID);
                db.EcologicalProblems.Add(problem);
                db.SaveChanges();

                return RedirectToAction("Complaints");
            }
            catch {
                return View();
            }
        }
        
        //Отклонение жалобы
        public ActionResult DeclineComplaint(int complaintID)
        {
            //Debug.WriteLine(complaintID);
            var complaint = db.Complaints.Find(complaintID);

            if (complaint != null)
            {
                complaint.IsHidden = true;
                TryUpdateModel<Complaint>(complaint);
                db.Entry<Complaint>(complaint).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Complaints");
        }

        //Создание жалобы
        [HttpGet]
        public ActionResult CreateComplaint()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Ecologist")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        [HttpPost]
        public ActionResult CreateComplaint(Complaint complaint)
        {
            if (complaint != null)
            {
                complaint.IsHidden = false; //открываем проблему
                complaint.Creator = db.Users.Find(Session["SystemUserID"]);
                db.Complaints.Add(complaint);
                db.SaveChanges();
            }

            return RedirectToAction("Complaints");
        }
                
        #endregion

        #region Экологические советы
        
        public ActionResult Councils()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Ecologist")
            {
                List<Council> councils = db.Councils.ToList();
                ViewBag.ecologist = db.Ecologists.Find(Session["SystemUserID"]);

                return View(councils);
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        //регистрация на совет 
        public ActionResult RegisterOnCouncil(int councilID)
        {
            var council = db.Councils.Find(councilID);
            var ecologist = db.Ecologists.Find(Session["SystemUserID"]);

            council.Ecologists.Add(ecologist);
            TryUpdateModel<Council>(council);
            db.Entry<Council>(council).State = System.Data.EntityState.Modified;
            db.SaveChanges();
                        
            return RedirectToAction("Councils");
        }

        //дерегистрация с совета
        public ActionResult DeregisterFromCouncil(int councilID)
        {
            var council = db.Councils.Find(councilID);
            var ecologist = db.Ecologists.Find(Session["SystemUserID"]);

            council.Ecologists.Remove(ecologist);
            TryUpdateModel<Council>(council);
            db.Entry<Council>(council).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("Councils");
        }

        #endregion
    }
}
