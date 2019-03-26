using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIAuthorization.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult Logoff ()
        {
            return View();
        }
    }
}
