using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_practice
{
    static class Logic
    {
        /// <summary>
        /// Counts amount of even elements in collection and shows number of element with number 9999
        /// </summary>
        /// <param name="persons"></param>
        static public void CalculateTimeForAction (ICollection<Person> persons)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Started");
            Console.WriteLine(persons.GetType().Name);
            Console.WriteLine(persons.Where(a => a._Id%2 == 0).Count());
            Console.WriteLine(persons.FirstOrDefault(b => b._internalNumber=="9999")._Id);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("Finished\n");
        }

        static public void CalculateTimeForAction (IDictionary<long, string> keyValuePairs)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Started");
            Console.WriteLine(keyValuePairs.GetType().Name);
            Console.WriteLine(keyValuePairs.Where(a => a.Key % 2 == 0).Count());
            Console.WriteLine(keyValuePairs.FirstOrDefault(b => b.Value == "9999").Key);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("Finished\n");
        }
    }
}
