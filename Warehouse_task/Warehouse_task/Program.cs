using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_task.Classes;

namespace Warehouse_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the our Warehouse\n" +
                "-------------------------------------");
            TV tv = new TV();
            Console.WriteLine("The {0} will expire {1}",tv.Name, 
                tv.CalculateEndDate(DateTime.Now));
        }
    }
}
