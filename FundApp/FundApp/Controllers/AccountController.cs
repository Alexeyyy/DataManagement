using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class AccountController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult Login()
        {
            return View();
        }

        //ЛОГИН --- ПРИНЯТИЕ ДАННЫХ
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            //Проверяем пусты ли введенные пользователем данные
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Введите все данные!");
            }

            //если валидация прошла успешно, то логинимся
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(n => n.Login == login && n.Password == password);
                    
                if (user != null)
                {
                    Session.Add("SystemUserID", user.ID);

                    //Проверим кто пытается войти в систему
                    if (user is Administrator)
                    {
                        Session.Add("Role", "Administrator");
                        Session.Add("Greeting", "Добро пожаловать! Администратор " + user.Name + " " + user.Surname);
                    }
                    if (user is RankUser)
                    {
                        Session.Add("Role", "User");
                        Session.Add("Greeting", "Добро пожаловать! Пользователь " + user.Name + " " + user.Surname);
                    }
                    if (user is Ecologist)
                    {
                        Session.Add("Role", "Ecologist");
                        Session.Add("Greeting", "Добро пожаловать! Эколог " + user.Name + " " + user.Surname);
                    }
                    if (user is Secretary)
                    {
                        Session.Add("Role", "Secretary");
                        Session.Add("Greeting", "Добро пожаловать! Секретарь " + user.Name + " " + user.Surname);
                    }

                    if (user is Partner)
                    {
                        if ((user as Partner).IsSolved)
                        {
                            Session.Add("Role", "Partner");
                            Session.Add("Greeting", "Добро пожаловать! Партнер " + user.Name + " " + user.Surname);
                        }
                        else
                        {
                            Session.Add("Role", "NotAllowed");
                        }
                    }
                    
                    Session.Add("ErrorLogin", false);
                }
                else
                {
                    //ModelState.AddModelError("Error", "Данные неверны!");
                    Session.Add("ErrorLogIn", true);
                }
            }

            if (!string.IsNullOrEmpty(Request.UrlReferrer.AbsolutePath))
            {
                return Redirect(Request.UrlReferrer.AbsolutePath);
            }

            return RedirectToAction("Index", "Home");
        }
                
        //ВЫХОД
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
