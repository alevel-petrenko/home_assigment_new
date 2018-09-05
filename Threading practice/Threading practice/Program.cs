using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool done = false;
            //List<int> attemps = new List<int>();
            //int answer = 6666;
            //Random rnd = new Random();
            //object locker = new object();

            //    Task t1 = new Task(() =>
            //    {
            //        Thread.Sleep(50);
            //        Go();
            //    }
            //    );
            //    Task t2 = new Task(() =>
            //    {
            //        Thread.Sleep(50);
            //        Go();
            //    }
            //    );
            //    Task t3 = new Task(() =>
            //    {
            //        Thread.Sleep(50);
            //        Go();
            //    }
            //    );
            //    Task t4 = new Task(() =>
            //    {
            //        Thread.Sleep(50);
            //        Go();
            //    }
            //    );
            //t1.Start();

            //void Go ()
            //{
            //    int number = rnd.Next(0, 1000);
            //    Console.WriteLine(number);
            //    if (!attemps.Contains(number))
            //    {
            //        attemps.Add(number);
            //    }
            //    else
            //    {
            //        lock (locker)
            //        {
            //            if (!done)
            //            {
            //                Console.WriteLine("Answer is found");
            //                done = true;
            //            }
            //        }
            //    }
            //}


            Task t1 = new Task(() =>
          {
              Thread.Sleep(2000);
              Console.WriteLine("First");
          });
            Task t2 = new Task(() =>
            {
                Thread.Sleep(5000);
              Console.WriteLine("Second");
            });
            Task t3 = new Task(() =>
            {
                Thread.Sleep(1000);
              Console.WriteLine("Third");
            });
            Task t4 = new Task(() =>
            {
                Thread.Sleep(4500);
              Console.WriteLine("Fourth");
            });
            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
