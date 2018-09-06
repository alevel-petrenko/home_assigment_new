using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Logic logic = new Logic();
            UI uI = new UI();
            logic.Start();
            uI.Start();

            //Thread.CurrentThread.Join();

            Console.ReadLine();
        }
    }
}