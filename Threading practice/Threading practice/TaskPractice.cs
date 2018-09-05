using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_practice
{
    class TaskPractice
    {
        static string[] names = new string[] { "Vasya", "Kolya", "Petya", "Dima" };

        public static void TaskOne()
        {
            var taskInt = Task.Run(() =>
           {
               var rnd = new Random();
               Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} is running");
               Thread.Sleep(1000);
               Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} is finished");
               return rnd.Next(1000);
           });

            var next = taskInt.ContinueWith(x =>
            {
                Console.WriteLine(x.Result * 10);
            }
            );
        }

        public static void TaskString ()
        {
            ///     Create a task chain of 4 tasks in a row
            ///     that will return one by one 4 names of 4 people
            ///     and print out all of them in the last chained task
            ///     now do it in for loop
            for (int i = 0; i < names.Length; i++)
            {
                Task t1 = new Task(() =>
              {

              });

            }
        }

        public static void CancalationOfTask()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var t1 = new Task(() =>
            {
               Thread.Sleep(5000);
                cancellationTokenSource.Cancel();

           }, cancellationTokenSource.Token);

            var t2 = new Task(() =>
          {
              while (!cancellationTokenSource.IsCancellationRequested)
                  Console.WriteLine("Hello world");
          });
        }
    }
}
