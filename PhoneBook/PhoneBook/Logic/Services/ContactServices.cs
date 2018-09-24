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
        public static List<Contact> _contacts = new List<Contact>
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
                        Id =1,
                        Type = PhoneTypes.Mobile,
                        Number = "0998765432"
                    },
                    new Phone
                    {
                        Id =2,
                        Type = PhoneTypes.Home,
                        Number = "0678760000"
                    },
                    new Phone
                    {
                        Id =3,
                        Type = PhoneTypes.Work,
                        Number = "321456789"
                    }
                }
            },

            new Contact ()
            {
                Name = "Mary Jane",
                Id = 2,
                Email = "jane@gmail.com",
                Phones = new List<Phone>
                {
                    new Phone
                    {
                        Id =1,
                        Type = PhoneTypes.Mobile,
                        Number = "03728761112"
                    },
                    new Phone
                    {
                        Id =2,
                        Type = PhoneTypes.Home,
                        Number = "0967160022"
                    },
                    new Phone
                    {
                        Id =3,
                        Type = PhoneTypes.Work,
                        Number = "07891156789"
                    }
                }
            },
            new Contact ()
            {
                Name = "Leo Di Caprio",
                Id = 3,
                Email = "inviroment@gmail.com",
                Phones = new List<Phone>
                {
                    new Phone
                    {
                        Id =1,
                        Type = PhoneTypes.Mobile,
                        Number = "0123456789"
                    },
                    new Phone
                    {
                        Id =2,
                        Type = PhoneTypes.Home,
                        Number = "0951753654"
                    },
                    new Phone
                    {
                        Id =3,
                        Type = PhoneTypes.Work,
                        Number = "0621453987"
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
            const int seed = 1;

            return _contacts.Any()
                        ? _contacts.Max(x => x.Id) + seed
                        : seed;
        }
    }
}
