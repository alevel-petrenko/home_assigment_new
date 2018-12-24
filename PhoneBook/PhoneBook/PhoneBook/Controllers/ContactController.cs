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
            ContactServices.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var contact = ContactServices.Get(id);
            return View(contact);
        }

        public ActionResult Details(int id)
        {
            var contact = ContactServices.Get(id);
            return View(contact);
        }
    }
}