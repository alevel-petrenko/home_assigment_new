using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    class Timer
    {
        DateTime start;
        
        public void Start()
        {
            start = DateTime.Now;
        }
        public void Finish()
        {
            Console.WriteLine();
        }
    }
}
