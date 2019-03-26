using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC_Author.Models;
using Newtonsoft.Json;

namespace MVC_Author.Controllers
{
    public class UserController : Controller
    {
        private string _APIpath = MVC_Author.Properties.Settings.Default.API;
        HttpClient client = new HttpClient();

        public async Task<ActionResult> Index()
        {
            IEnumerable<User> users = null;

            string json = await client.GetStringAsync($"{_APIpath}/UsersDB");

            users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);

            return View(users);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(user);

                HttpResponseMessage response = await client.PutAsJsonAsync($"{_APIpath}/UsersDB", user);
                return RedirectToAction("User", "Index");
            }
            return View();
        }
    }
}