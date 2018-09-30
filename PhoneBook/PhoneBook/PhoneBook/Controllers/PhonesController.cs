using Logic.Models;
using Logic.Services;
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
            var phone = PhoneServices.Get(id);
            return View(phone);
        }

        [HttpPost]
        public ActionResult Update(Phone phone)
        {
            if (ModelState.IsValid)
            {
                PhoneServices.UpdatePhone(phone);
                return RedirectToAction("Index", "Contact");
            }
            else
                return View("Update", phone);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Phone phone)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete (int id)
        {
            var phone = PhoneServices.Get(id);

            return View(phone);
        }

        [HttpPost]
        public ActionResult Delete (Phone phone)
        {
            if (phone != null)
            {
                PhoneServices.DeletePhone(phone.Id);

                return RedirectToAction("Index", "Contact");
            }
            else
                return RedirectToAction("Index", "Phones");
        }
    }
}