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

        #region Выбор
        public ActionResult SignUpChoice()
        {
            return View();
        }
        #endregion

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
                registeredUser.ItemRankUser.RegistrationDate = DateTime.Now;

                db.RankUsers.Add(registeredUser.ItemRankUser);
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
    }
}
