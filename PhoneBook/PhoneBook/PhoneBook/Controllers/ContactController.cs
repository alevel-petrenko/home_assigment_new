using Logic.Models;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class ContactController : Controller
    {

        // GET: Contact
        public ActionResult Index()
        {
            var contact = ContactServices.GetAll();
            return View(contact);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Contact model)
        {
            if (ModelState.IsValid)
            {
                ContactServices.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var contact = ContactServices.Get(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ContactServices.Update(contact);
                return RedirectToAction("Index");
            }
            else
            {
                return View(contact);
            }
        }

        public ActionResult Details(int id)
        {
            var contact = ContactServices.Get(id);
            return View(contact);
        }
    }
}