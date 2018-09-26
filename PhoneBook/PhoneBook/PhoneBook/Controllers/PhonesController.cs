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
            PhoneServices.CopyPhones();

            var phone = PhoneServices.Get(id);
            return View(phone);
        }

        [HttpPost]
        public ActionResult Update(Phone phone)
        {
            PhoneServices.CopyPhones();

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
            PhoneServices.CopyPhones();

            return View();
        }

        [HttpPost]
        public ActionResult Add(Phone phone)
        {
            PhoneServices.CopyPhones();

            return View();
        }

        [HttpGet]
        public ActionResult Delete(Phone phone)
        {
            PhoneServices.CopyPhones();

            return View();
        }

        [HttpDelete]
        public ActionResult Delete (int id)
        {
            PhoneServices.Delete(id);
            return RedirectToAction("Index", "Contact");
        }
    }
}