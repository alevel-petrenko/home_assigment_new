using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public static class PhoneService
    {
        private static List<Phone> _phones;

        //public PhoneService(List<Phone> phones)
        //{
        //    _phones = phones;
        //}

        public static void UpdatePhone(Phone phone)
        {
            _phones.RemoveAt(phone.Id);
            _phones.Insert(phone.Id, phone);
        }

        public static void AddPhone(Phone phone)
        {
            _phones.Add(phone);
        }
    }
}
