using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundApp.Models;

namespace FundApp.Controllers
{
    public class RegistrationController : Controller
    {
        FundContext db = new FundContext();

        public ActionResult SignUpChoice()
        {
            return View();
        }

        //Проверяем есть ли уже пользователь под таким же логином
        public bool IsNewLoginValid(string login)
        {
            if (db.Users.Count(n => n.Login == login) == 0)
                return true;
            else
                return false;
        }

        #region Для пользователя
        public ActionResult SignUpFormRankUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpFormRankUser(RegistrationViewModel registeredUser)
        {
            if (ModelState.IsValid)
            {
                if (!IsNewLoginValid(registeredUser.ItemRankUser.Login))
                {
                    ViewBag.login = registeredUser.ItemRankUser.Login;
                    return View(registeredUser);
                }
                else
                {
                    registeredUser.ItemRankUser.RegistrationDate = DateTime.Now;
                    
                    db.RankUsers.Add(registeredUser.ItemRankUser);
                    db.SaveChanges();

                    return View("RegistrationResult");
                }
            }
            else
            {
                //при возникновении ошибки возвращаем данные пользователя 
                return View(registeredUser);
            }
        }
        #endregion

        #region Для эколога
        public ActionResult SignUpFormEcologist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpFormEcologist(RegistrationViewModel registeredUser)
        {
            if (ModelState.IsValid)
            {
                if (!IsNewLoginValid(registeredUser.ItemEcologist.Login))
                {
                    ViewBag.login = registeredUser.ItemEcologist.Login;
                    return View(registeredUser); 
                }

                registeredUser.ItemEcologist.RegistrationDate = DateTime.Now;

                db.Ecologists.Add(registeredUser.ItemEcologist);
                db.SaveChanges();

                return View("RegistrationResult");
            }
            else
            {
                //при возникновении ошибки возвращаем данные пользователя 
                return View(registeredUser);
            }
        }
        #endregion

        #region Для партнера
        public ActionResult SignUpFormPartner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpFormPartner(Partner registeredPartner)
        {
            if (!IsNewLoginValid(registeredPartner.Login))
            {
                ViewBag.login = registeredPartner.Login;
                return View(registeredPartner);
            }

            registeredPartner.RegistrationDate = DateTime.Now;
            registeredPartner.IsSolved = false; //секретарь еще не принял заявку

            registeredPartner.Secretary = db.Secretaries.FirstOrDefault();
            
            try
            {
                db.Partners.Add(registeredPartner);
                db.SaveChanges();

                ViewBag.regResult = true;

                return View("RegistrationResult");
            }
            catch
            {
                ViewBag.regResult = false;
                return View("RegistrationResult");
            }
        }
        #endregion
    }
}
