using Square_Logic.Models;
using Square_Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Square.Controllers
{
    public class DecisionController : Controller
    {
        // GET: Decision
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Inputs model)
        {
            ICalculateService calculateService = new CalculateServiceMoke();

            calculateService.Calculate(model);

            return View(model);
        }
    }
}