using Asp_Preview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_Preview.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ControlTable()
        {
            return View();
        }

        public ActionResult Summ(SummModel model)
        {
            model.Result = model.First + model.Second;

            return View(model);
        }

        public ActionResult Multiply(SummModel instance)
        {
            instance.Result = instance.First * instance.Second;

            return View(instance);
        }
    }
}