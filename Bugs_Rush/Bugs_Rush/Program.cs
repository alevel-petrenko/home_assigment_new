using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Task t1 = new Task(() =>
            {
                Bug bug1 = new Bug('&', 1, 1);
                bug1.Move();
            });

            Task t2 = new Task(() =>
            {
                Bug bug2 = new Bug('$', 2, 1);
                bug2.Move();
            });

            Task t3 = new Task(() =>
            {
                Bug bug3 = new Bug('#', 3, 1);
                bug3.Move();
            });
            t1.Start();
            t2.Start();
            t3.Start();
            UI.
            Console.ReadLine();
        }
    }
}