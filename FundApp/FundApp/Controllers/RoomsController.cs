using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FundApp.Controllers
{
    public class RoomsController : Controller
    {
        #region Administrator
        
        public ActionResult AdministratorRoom()
        {
            return View();
        }
        
        #endregion

        #region User

        public ActionResult UserRoom()
        {
            return View();
        }
        
        #endregion

    }
}
