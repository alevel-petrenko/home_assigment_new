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
            // List <T>
            List<Person> listPersons = Person.GetPersonsGenCollection<List<Person>>(5000000);
            Logic.CalculateTimeForAction(listPersons);
            // Dictionary<K,V>
            Dictionary<long, string> dictionaryPersons = Person.GetPersonsToDictionary<Dictionary<long, string>>(5000000);
            Logic.CalculateTimeForAction(dictionaryPersons);
            // HashSet <T>
            HashSet<Person> hashSetPersons = Person.GetPersonsGenCollection<HashSet<Person>>(5000000);
            Logic.CalculateTimeForAction(hashSetPersons);
            // Hashtable
            Hashtable hashTablePersons = Person.GetPersonsHashtable<Hashtable>(5000000);
            //CalculateTimeForAction
            // Linkedlist <T>
            LinkedList<Person> linkedListPersons = Person.GetPersonsGenCollection<LinkedList<Person>>(5000000);
            Logic.CalculateTimeForAction(linkedListPersons);
            // Stack <T>
            Stack<Person> stackPersons = Person.GetPersonsCollection<Stack<Person>>(5000000);
            Logic.CalculateTimeForAction(stackPersons);
        }
    }
}
