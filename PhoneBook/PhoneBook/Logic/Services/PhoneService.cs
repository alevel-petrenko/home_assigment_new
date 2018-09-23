using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    class PhoneService
    {
        public static void UpdatePhone(Contact contact, Phone phone)
        {
            var oldContact = Get(contact.Id);

            oldContact.Phones.RemoveAt(phone.Id);
            oldContact.Phones.Insert(phone.Id, phone);
        }

        public static void AddPhone(Contact contact, Phone phone)
        {
            contact.Phones.Add(phone);
        }
    }
}
