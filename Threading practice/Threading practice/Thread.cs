using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_practice
{
    class ThreadTest
    {
        public void ThreadExample()
        {
            //    Thread t = new Thread(WriteY);          // Kick off a new thread
            //    t.Name = "Name";
            //    t.Start();                               // running WriteY()

            //    // Simultaneously, do something on the main thread.
            //    for (int i = 0; i < 1000; i++) Console.Write("x");
            //}

            //static void WriteY()
            //{
            //    for (int i = 0; i < 1000; i++) Console.Write("y");
            Task t1 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Thread ID {Thread.CurrentThread.ManagedThreadId} finished");
            });

            Task t2 = new Task(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Thread ID {Thread.CurrentThread.ManagedThreadId} finished");
            });
            t1.Start();
            t2.Start();
            //t2.Result();
            var str = GetString();
            Console.WriteLine( str.Result );

            Console.WriteLine("Press key");
            Console.ReadLine();
        }

        public static Task<string> GetString()
        {
            return Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                return "";
            });
        }
    }
}

