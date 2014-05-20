using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FundApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult General(Exception exception)
        {
            return View(exception);
        }

        public ActionResult Http404()
        {
            return View();
        }

        public ActionResult Http403()
        {
            return View();
        }
    }
}
