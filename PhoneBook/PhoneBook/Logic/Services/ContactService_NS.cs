using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{   //example for showing disadvantages of Dependency Invertion
    public class ContactService_NS : IContactService_Ns
    {
        List<Contact> IContactService_Ns.GetAll()
        {
            return ContactServices.GetAll();
        }
    }

    public interface IContactService_Ns
    {
        List<Contact> GetAll();
    }

    public class CSMock : IContactService_Ns
    {
        public List<Contact> GetAll()
        {
            return new List<Contact>
            {
                new Contact ()
                {
                    Name = "Lebron",
                    Id = 1,
                    Email = "snba@mail.com",
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
                }
            };
        }
    }

    public class CSExtended : IContactService_Ns
    {
        public List<Contact> GetAll()
        {
            var list = ContactServices.GetAll();
            list.Select(a => a.Name = $"mr. {a.Name}");
            return list;
        }
    }
}
