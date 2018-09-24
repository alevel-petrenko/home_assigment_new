﻿using Logic.Models;
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
            var contact = ContactServices.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult Update(Phone phone)
        {
            if (ModelState.IsValid)
            {
                //ContactServices.UpdatePhone(phone);
                return RedirectToAction("Index", "Contact");
            }
            else
                return View();
        }
    }
}