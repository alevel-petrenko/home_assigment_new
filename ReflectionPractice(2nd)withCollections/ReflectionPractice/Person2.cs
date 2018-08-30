using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    class Person2
    {
        private const int mod = 99;
        public int _Id { get; set; }
        public string _internalNumber { get; set; }

        public Person2(int Id)
        {
            _Id = Id;
            _internalNumber =  Convert.ToString(Id*mod);
        }

        public static List<Person2> AddingItems(int number)
        {
            List<Person2> listPerson2 = new List<Person2>();

            for (int i = 0; i < number; i++)
            {
                listPerson2.Add(new Person2(i));
            }
            return listPerson2;
        }

        public T GetPersonsCollection<T>(int count) where T : ICollection<Person2>, new()
        {
            T response = new T();

            for (int i = 0; i < count; i++)
            {
                response.Add(new Person2(i));
            }
            return response;
        }

    }
}
