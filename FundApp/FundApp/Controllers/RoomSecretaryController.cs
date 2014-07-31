using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;
using FundApp.Models.ViewModels;

namespace FundApp.Controllers
{
    public class RoomSecretaryController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult SecretaryRoom()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
                return View();
            else
                return RedirectToAction("Http403", "Error");
        }

        #region Заявки

        //Отображение списка заявок
        public ActionResult Requests()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
                return View(db.Partners.Where(n => n.IsSolved == false).ToList());
            else
                return RedirectToAction("Http403", "Error");
        }

        //Удаление заявки   
        public ActionResult DeleteRequest(int requestID)
        {
            var request = db.Partners.Find(requestID);

            if (request != null)
            {
                db.Partners.Remove(request);
                db.SaveChanges();
            }

            return View("Requests", db.Partners.Where(n => n.IsSolved == false).ToList());
        }

        //Принятие заявки
        public ActionResult AcceptRequest(int requestID)
        {
            var request = db.Partners.Find(requestID);
            Debug.WriteLine(Session["SystemUserID"]);

            if (request != null)
            {
                request.IsSolved = true;
                request.Secretary = db.Secretaries.Find(Session["SystemUserID"]);
                db.SaveChanges();
            }

            return View("Requests", db.Partners.Where(n => n.IsSolved == false).ToList());
        }

        #endregion

        #region Экологические советы

        //Получим список проблем для View
        private SelectListItem[] GetProblemsList(int id)
        {
            List<EcologicalProblem> problems = db.EcologicalProblems.ToList();
            SelectListItem[] list = new SelectListItem[problems.Count];

            for (int i = 0; i < list.Length; i++)
            {
                if (problems[i].ProblemID == id)
                    list[i] = new SelectListItem() { Text = problems[i].Title, Selected = true, Value = problems[i].ProblemID.ToString() };
                else
                    list[i] = new SelectListItem() { Text = problems[i].Title, Selected = false, Value = problems[i].ProblemID.ToString() };
            }

            return list;
        }

        //Отображение экологических советов
        public ActionResult Councils()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
            {
                //Скрывать ли ссылку создания совета или нет
                if (db.Councils.ToList().Count == db.EcologicalProblems.ToList().Count)
                    ViewBag.showCreateLink = false;
                else
                    ViewBag.showCreateLink = true;

                CouncilsProblems list = new CouncilsProblems();
                list.listCouncils = db.Councils.ToList();
                list.listProblems = (from problem in db.EcologicalProblems
                                     select problem).ToList();

                return View(list);
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        //Запрос на проблемы
        [HttpGet]
        public ActionResult GetCrucialProblems(string daysRange)
        {
            CouncilsProblems list = new CouncilsProblems();
            list.listCouncils = db.Councils.ToList();
            int days;

            if (int.TryParse(daysRange, out days))
            {
                try
                {
                    list.listProblems = db.Database.SqlQuery<EcologicalProblem>("GetEcologicalProblems @days_range", new SqlParameter("days_range", days)).ToList();
                    int l = list.listProblems.Count;
                }
                catch
                {
                    list.listProblems = (from problem in db.EcologicalProblems
                                         select problem).ToList();
                }
            }
            else
            {
                list.listProblems = (from problem in db.EcologicalProblems
                                     select problem).ToList();
            }

            //Скрывать ли ссылку создания совета или нет
            if (db.Councils.ToList().Count == db.EcologicalProblems.ToList().Count)
                ViewBag.showCreateLink = false;
            else
                ViewBag.showCreateLink = true;

            return View("Councils", list);
        }

        //Удаление совета
        public ActionResult DeleteCouncil(int councilID)
        {
            var council = db.Councils.Find(councilID);

            if (council != null)
            {
                council.Ecologists.Clear();
                db.Councils.Remove(council);
                db.SaveChanges();
            }


            return RedirectToAction("Councils");
        }

        //Редактирование совета
        [HttpGet]
        public ActionResult EditCouncil(int councilID)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
            {
                int problemID = db.Councils.Find(councilID).Problem.ProblemID;
                //ViewBag.problems = GetProblemsList(problemID);
                ViewBag.problemID = problemID;

                return View(db.Councils.Find(councilID));
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        [HttpPost]
        public ActionResult EditCouncil(Council c, int problemID)
        {
            ViewBag.problems = GetProblemsList(problemID); //отсылка в View
            var council = db.Councils.Find(c.CouncilID); //редактируемый совет

            council.Problem = db.EcologicalProblems.Find(problemID);

            TryUpdateModel<Council>(council);
            db.Entry<Council>(council).State = System.Data.EntityState.Modified;

            db.SaveChanges();

            //Debug.WriteLine(c.Problem.ProblemID);
            var problem = db.EcologicalProblems.Find(problemID);
            bool result = db.Councils.Find(c.CouncilID).CounsilResult; ;
            string name = problem.Title;

            problem.IsSolved = result;

            TryUpdateModel<EcologicalProblem>(problem);
            db.Entry<EcologicalProblem>(problem).State = System.Data.EntityState.Modified;

            db.SaveChanges();

            problem.Title = name;
            db.SaveChanges();

            return RedirectToAction("Councils");
        }

        //СОЗДАНИЕ ЭКОЛОГИЧЕСКОГО СОВЕТА

        //При создании необходимо учесть, что проблемы, которые будут уже рассматриваются не включать
        private SelectListItem[] GetNonOverviewedProblems()
        {
            List<EcologicalProblem> problems = db.EcologicalProblems.ToList();
            List<Council> councils = db.Councils.ToList();

            for (int i = 0; i < councils.Count; i++)
            {
                int j = 0;
                while (j < problems.Count)
                {
                    if (councils[i].Problem.ProblemID == problems[j].ProblemID)
                    {
                        problems.Remove(problems[j]);
                    }
                    else
                        j++;
                }
            }

            if (problems.Count != 0)
            {
                SelectListItem[] list = new SelectListItem[problems.Count];

                for (int i = 0; i < list.Length; i++)
                {
                    //if (i == 0)
                    list[i] = new SelectListItem() { Text = problems[i].Title, Selected = true, Value = problems[i].ProblemID.ToString() };
                    //else
                    //  list[i] = new SelectListItem() { Text = problems[i].Title, Selected = false, Value = problems[i].ProblemID.ToString() };
                }

                return list;
            }
            else
                return null;
        }

        [HttpGet]
        public ActionResult CreateCouncil()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
            {
                SelectListItem[] list = GetNonOverviewedProblems();

                if (list != null)
                {
                    ViewBag.problems = GetNonOverviewedProblems();
                    return View();
                }
                else
                {
                    return RedirectToAction("Councils");
                }
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        [HttpPost]
        public ActionResult CreateCouncil(Council c, int problemID)
        {
            Debug.WriteLine(problemID);
            var problem = db.EcologicalProblems.Find(problemID);
            try
            {
                c.Problem = problem;
                db.Councils.Add(c);
                db.SaveChanges();

                return RedirectToAction("Councils");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Организации-штрафники

        //Формирование страницы
        [HttpGet]
        public ActionResult Debtors()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
            {
                //возвращаем в View нужные данные для формирования двух таблиц
                DebtorComplaint list = new DebtorComplaint();
                list.listComplaints = db.Complaints.ToList();
                list.listDebtors = db.OrganisationDeptors.ToList();

                return View(list);
            }
            else
            {
                return RedirectToAction("Http403", "Error");
            }
        }

        //Удаление должника
        public ActionResult DeleteDebtor(int debtorID)
        {
            var debtor = db.OrganisationDeptors.Find(debtorID);

            if (debtor != null)
            {
                db.OrganisationDeptors.Remove(debtor);
                db.SaveChanges();
            }

            return RedirectToAction("Debtors");
        }

        //Создание должника
        [HttpGet]
        public ActionResult CreateDebtor(int complaintID)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
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
        public ActionResult CreateDebtor(OrganisationDeptor d, int complaintID)
        {
            Debug.WriteLine(d.Name);
            try
            {
                d.Complaint = db.Complaints.Find(complaintID);
                db.OrganisationDeptors.Add(d);
                db.SaveChanges();

                return RedirectToAction("Debtors");
            }
            catch
            {
                ViewBag.complaintID = complaintID;
                return View();
            }
        }

        //Редактирование должника
        [HttpGet]
        public ActionResult EditDebtor(int debtorID)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Secretary")
            {
                var debtor = db.OrganisationDeptors.Find(debtorID);
                return View(debtor);
            }
            else
            {
                return RedirectToAction("Http403", "Error"); 
            }
        }

        [HttpPost]
        public ActionResult EditDebtor(OrganisationDeptor d)
        {
            var debtor = db.OrganisationDeptors.Find(d.OrganisationDeptorID);
            TryUpdateModel<OrganisationDeptor>(debtor);
            db.Entry<OrganisationDeptor>(debtor).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Debtors");
        }

        //Фильтрация должников
        [HttpGet]
        public ActionResult PayedDebtorFilter()
        {
            DebtorComplaint list = new DebtorComplaint();
            list.listComplaints = db.Complaints.ToList();
            list.listDebtors = (from debtor in db.OrganisationDeptors
                                where debtor.IsPayed == true
                                select debtor).ToList();

            return View("Debtors", list);
        }

        [HttpGet]
        public ActionResult UnpayedDebtorFilter()
        {
            DebtorComplaint list = new DebtorComplaint();
            list.listComplaints = db.Complaints.ToList();
            list.listDebtors = (from debtor in db.OrganisationDeptors
                                where debtor.IsPayed == false
                                select debtor).ToList();

            return View("Debtors", list);
        }


        //Запрос на должника
        public ActionResult QueryForCrucialDebtors()
        {
            DebtorComplaint list = new DebtorComplaint();

            list.listDebtors = db.Database.SqlQuery<OrganisationDeptor>("GetCrucialDebtor @day_count", new SqlParameter("day_count", 3)).ToList();
            list.listComplaints = db.Complaints.ToList();

            return View("Debtors", list);
        }
        #endregion
    }
}


































