using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class PhonesController : Controller
    {
        // GET: Phones
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(Phone phone)
        {

            return RedirectToAction("Index", "Contacts");
        }
    }
}