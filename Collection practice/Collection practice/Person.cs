using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_practice
{
    class Person
    {
        private const int mod = 99;
        public long _Id { get; set; }
        public string _internalNumber { get; set; }

        public Person(long Id)
        {
            _Id = Id;
            _internalNumber = Convert.ToString(Id * mod);
        }

        public static List<Person> AddingItems(int number)
        {
            List<Person> listPerson = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                listPerson.Add(new Person(i));
            }
            return listPerson;
        }

        public static ICollection GetPersonsHashtable(long number)
        {
            Hashtable ht = new Hashtable();
            for (long i = 0; i < number; i++)
            {
                ht.Add(i, Convert.ToString(i * mod));
            }
            return ht;
        }

        public static T GetPersonsToDictionary<T> (long number) where T : IDictionary<long, string>, new()
        {
            T keyValues = new T();
            for (long i = 0; i < number; i++)
            {
                keyValues.Add(i, Convert.ToString(i * mod));
            }
            return keyValues;
        }

        public static T GetPersonsCollection<T>(long count) where T : ICollection<Person>, new()
        {
            T response = new T();

            for (long i = 0; i < count; i++)
            {
                response.Add(new Person(i));
            }
            return response;
        }
    }
}
