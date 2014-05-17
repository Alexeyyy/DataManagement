using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FundApp.Models;
using FundApp.Models.ViewModels;

namespace FundApp.Controllers
{
    public class RoomAdministratorController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult AdministratorRoom()
        {
            var adults = db.Database.SqlQuery<int>("SELECT [dbo].[GetAdultsQuantity] ()").FirstOrDefault();
            var children = db.Database.SqlQuery<int>("SELECT [dbo].[GetChildrenQuantity] ()").FirstOrDefault();

            ViewBag.adultsQuantity = adults;
            ViewBag.childrenQuantity = children;

            return View();
        }

        #region Работа с пользователями
        
        //Отображение страницы со списком пользователей
        public ActionResult SystemUsers()
        {
            //Вернем всех пользователей, кроме администратора, а то не Дай Бог еще себя любимых удалим
            List<User> users = db.Users.Where(n => !(n is Administrator)).ToList();
            

            return View(users);
        }

        //Удаление пользователя 
        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id);

            if (user != null)
            {
                try
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                catch { }
            }

            return RedirectToAction("SystemUsers");
        }

        //Добавление нового пользователя
        public ActionResult AddNewUser() {
            return RedirectToAction("SignUpChoice", "Registration", null);
        }

        //Поиск по фамилии/имени/отчеству
        [HttpGet]
        public ActionResult SearchUser(string searchString)
        {
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var users = (from n in db.Users
                             where (!(n is Administrator) && (n.Name.Contains(searchString) || n.Surname.Contains(searchString) || n.FatherName.Contains(searchString)))
                             select n).ToList();

                return View("SystemUsers", users);
            }
            else
            {
                var users = (from n in db.Users
                             where (!(n is Administrator))
                             select n).ToList();

                return View("SystemUsers", users);
            }
        }

        #endregion

        #region Новости

        //Отображение
        public ActionResult CreateNews(int id)
        {
            ViewBag.problemID = id;

            return View();
        }

        public ActionResult SystemNewsCreation()
        {
            return View(db.EcologicalProblems.ToList());
        }

        //Создаем новость
        [HttpPost]
        public ActionResult CreateNews(AddAchievement achievement, int ecologicalProblemID)
        {
            ViewBag.problemID = ecologicalProblemID;            
            int currentAdminId;

            if (int.TryParse(Session["SystemUserId"].ToString(), out currentAdminId))
            {
                try
                {
                    achievement.AchievementItem.Administrator = db.Administrators.Find(currentAdminId);
                    achievement.AchievementItem.EcologicalProblem = db.EcologicalProblems.Find(ecologicalProblemID);

                    if (achievement.ImageFile != null)
                    {
                        var image = new WebImage(achievement.ImageFile.InputStream);
                        image.Resize(200, 133);

                        achievement.AchievementItem.PhotoType = achievement.ImageFile.ContentType;
                        achievement.AchievementItem.PhotoFile = image.GetBytes();
                    }

                    db.Achivements.Add(achievement.AchievementItem);
                    db.SaveChanges();

                    return RedirectToAction("SystemNewsCreation");
                }
                catch { }
            }

            return View();
        }

        //Редактирование новости
        [HttpGet]
        public ActionResult EditNews(int id)
        {
            AddAchievement item = new AddAchievement();
            item.AchievementItem = db.Achivements.Find(id);
            
            return View(item);
        }
                
        [HttpPost]
        public ActionResult EditNews(AddAchievement a)
        {
            var achievement = db.Achivements.Find(a.AchievementItem.AchievementID);

            if (a.ImageFile != null)
            {
                var image = new WebImage(a.ImageFile.InputStream);
                image.Resize(200, 133);

                achievement.PhotoType = a.ImageFile.ContentType;
                achievement.PhotoFile = image.GetBytes();
            }

            TryUpdateModel<Achievement>(achievement);
            db.Entry<Achievement>(achievement).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SystemNewsCreation");
        }

        //Удаление новости
        public ActionResult DeleteNews(int achievementID)
        {
            var achievement = db.Achivements.Find(achievementID);

            if (achievement != null)
            {
                db.Achivements.Remove(achievement);
                db.SaveChanges();
            }

            return RedirectToAction("SystemNewsCreation");
        }

        //Фильтрация
        [HttpGet]
        public ActionResult SolvedProblemFilter()
        {
            var filteredProblems = (from problem in db.EcologicalProblems 
                                    where problem.IsSolved == true 
                                    select problem).ToList();

            return View("SystemNewsCreation", filteredProblems);
        }

        [HttpGet]
        public ActionResult UnsolvedProblemFilter()
        {
            var filteredProblems = (from problem in db.EcologicalProblems
                                    where problem.IsSolved == false
                                    select problem).ToList();

            return View("SystemNewsCreation", filteredProblems);

        }
      
        #endregion
        
        #region Экологические кружки

        //Отображение страницы с секциями 
        [HttpGet]
        public ActionResult SystemSections()
        {
            return View(db.Sections.ToList());
        }

        private SelectListItem[] GetEcologistsSurnames(int id)
        {
            List<Ecologist> availableEcologists = db.Ecologists.ToList();
            SelectListItem[] list = new SelectListItem[availableEcologists.Count];

            for (int i = 0; i < list.Length; i++)
            {
                if (availableEcologists[i].ID == id)
                    list[i] = new SelectListItem() { Text = availableEcologists[i].Surname, Selected = true, Value = availableEcologists[i].ID.ToString() };
                else
                    list[i] = new SelectListItem() { Text = availableEcologists[i].Surname, Selected = false, Value = availableEcologists[i].ID.ToString() };
            }
            
            return list;
        }

        //Создание экологической секции
        [HttpGet]
        public ActionResult CreateSection()
        {
            ViewBag.ecologists = GetEcologistsSurnames(1); //при создании первый эколог будет выбран по умолчанию  

            return View();
        }
        
        [HttpPost]
        public ActionResult CreateSection(Section s, int ecologistID)
        {
            ViewBag.ecologists = GetEcologistsSurnames(ecologistID);
            //Debug.WriteLine(ecologistID + " " + ecologistID.GetType());
            try
            {
                s.Ecologist = db.Ecologists.Find(ecologistID);
                
                //s.CalculateParticipantsCount();
                //s.CalculateFreeSpots();

                db.Sections.Add(s);
                db.SaveChanges();

                return RedirectToAction("SystemSections");
            }
            catch 
            {
                return View();
            }
        }

        //Удаление информации о секции
        public ActionResult DeleteSection(int sectionID)
        {
            var section = db.Sections.Find(sectionID);

            if (section != null)
            {
                db.Sections.Remove(section);
                db.SaveChanges();
            }

            return RedirectToAction("SystemSections");
        }

        //Редактирование секции
        [HttpGet]
        public ActionResult EditSection(int sectionID)
        {
            int ecologistID = db.Sections.Find(sectionID).Ecologist.ID;
            ViewBag.ecologists = GetEcologistsSurnames(ecologistID);
            
            return View(db.Sections.Find(sectionID));
        }

        [HttpPost]
        public ActionResult EditSection(Section s, int ecologistID)
        {
            ViewBag.ecologists = GetEcologistsSurnames(ecologistID); //учитываем dropdown list
            
            var section = db.Sections.Find(s.SectionID);
            section.Ecologist = db.Ecologists.Find(ecologistID);

            TryUpdateModel<Section>(section);

            //расчет двух "столбцов"
            section.CalculateParticipantsCount();
            section.CalculateFreeSpots();
                                                
            db.Entry<Section>(section).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("SystemSections"); 
        }

        #endregion
    }
}
