using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public static class ContactServices
    {
        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact ()
            {
                Name = "Steph Curry",
                Id = 1,
                Email = "sc@mail.com",
                Phones = new List<Phone>
                {
                    new Phone
                    {
                        Type = 1,
                        Number = "09987654321"
                    }
                }
            }
        };

        public static int Create(Contact contact)
        {
            contact.Id = GetMax();

            _contacts.Add(contact);

            return contact.Id;
        }
        public static void Delete(int id)
        {
            var contact = Get(id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
        public static Contact Get(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
        public static List<Contact> GetAll()
        {
            return _contacts.OrderBy(x => x.Name).ToList();
        }

        public static void Update(Contact contact)
        {
            var oldContact = Get(contact.Id);

            oldContact.Email = contact.Email;
            oldContact.Name = contact.Name;
            oldContact.Phones = contact.Phones;
        }

        private static int GetMax()
        {
            return _contacts.Max(x => x.Id) + 1;
        }
    }
}
