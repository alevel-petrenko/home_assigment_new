using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    static class LogicForLists
    {
        static void InvokeActionsList(ICollection<Action> actionCollection)
        {

        }

        public static List<Action<List<Person>>> InvokeList { get; set; }
    }
}
