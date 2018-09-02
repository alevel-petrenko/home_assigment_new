using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<T>
            List<Person> listPersons = Person.GetPersonsCollection<List<Person>>(5000000);
            Logic.CalculateTimeForAction(listPersons);
            // Dictionary<K,V>
            Dictionary<long, string> dictionaryPersons = Person.GetPersonsToDictionary<Dictionary<long, string>>(5000000);
            Logic.CalculateTimeForAction(dictionaryPersons);
            // HashSet
            HashSet<Person> hashSetPersons = Person.GetPersonsCollection<HashSet<Person>>(5000000);
            Logic.CalculateTimeForAction(hashSetPersons);
            // Hashtable
            Hashtable hashTablePersons = new Hashtable();

            // Linkedlist
            LinkedList<Person> linkedListPersons = Person.GetPersonsCollection<LinkedList<Person>>(5000000);
            Logic.CalculateTimeForAction(linkedListPersons);
        }
    }
}
