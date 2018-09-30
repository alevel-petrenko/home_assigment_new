using Logic.Services;
using PhoneBook_UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook_UI.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _contactService = new Services.ContactServices();

        public async Task<ActionResult> Index()
        {
            var list = await _contactService.GetAll();

            return View(list);
        }

        public async Task<ActionResult> About()
        {
            var contact = await _contactService.Get(2);

            return View(contact);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}