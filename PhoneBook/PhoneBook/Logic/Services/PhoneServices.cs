using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public static class PhoneServices
    {
        private static List<Phone> _phones;

        public static void CopyPhones()
        {
            if (_phones == null)
            {
                _phones = new List<Phone>();
                foreach (var person in ContactServices.contacts)
                {
                    foreach (var phone in person.Phones)
                    {
                        _phones.Add(phone);
                    }
                }
            }
        }

        public static Phone Get(int id)
        {
            return _phones.FirstOrDefault(x => x.Id == id);
        }

        public static void UpdatePhone(Phone phone)
        {
            var oldPhone = Get(phone.Id);
            oldPhone.Number = phone.Number;
            oldPhone.Type = phone.Type;

        }

        public static void AddPhone(Phone phone)
        {
            phone.Id = GetMax();
            _phones.Add(phone);
        }

        private static int GetMax()
        {
            const int seed = 1;
            return _phones.Any() ? _phones.Max(x => x.Id) + seed : seed;
        }

        public static void DeletePhone (int id)
        {
            _phones.Remove(Get(id));
        }
    }
}
