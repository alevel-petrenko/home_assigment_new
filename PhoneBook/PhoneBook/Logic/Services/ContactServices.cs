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
                        Type = PhoneTypes.Mobile,
                        Number = "03728761112"
                    },
                    new Phone
                    {
                        Type = PhoneTypes.Home,
                        Number = "0967160022"
                    },
                    new Phone
                    {
                        Type = PhoneTypes.Work,
                        Number = "07891156789"
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

        private static List<Phone> GetMockedPhones()
        {
            return new List<Phone>
            {
                new Phone
                {
                    Id =1,
                    Number= "09999999999",
                    Type = (PhoneTypes) 1
                },
                new Phone
                {
                    Id =2,
                    Number= "0888888888",
                    Type = (PhoneTypes) 2
                },
                new Phone
                {
                    Id =3,
                    Number= "0777777777",
                    Type = (PhoneTypes) 3
                },
            };
        }
    }
}
