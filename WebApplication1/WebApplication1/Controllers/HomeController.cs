using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        PhoneContext PhoneContext = new PhoneContext();

        public ActionResult Index()
        {
            // извлекаем данные из таблицы
            IEnumerable<Phone> phones = PhoneContext.Phones;
            // 
            ViewBag.Phones = phones;

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public string Buy (Purchase purchase)
        {
            purchase.Time = DateTime.Now;
            PhoneContext.Purchases.Add(purchase);
            PhoneContext.SaveChanges();
            return $"Dear, {purchase.FIO}, you will get call soon";
        }
    }
}