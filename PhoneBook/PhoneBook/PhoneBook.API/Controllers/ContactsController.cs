using Logic.Models;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBook.API.Controllers
{
    public class ContactsController : ApiController
    {
        [HttpGet]
        public IEnumerable<Contact> Get ()
        {
            var contacts = ContactServices.GetAll();
            return contacts;
        }

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var contact = ContactServices.Get(Id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public IHttpActionResult Post (Contact contact)
        {
            ContactServices.Create(contact);

            return Ok();
        }
    }
}
