using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    class Logic
    {
        public static int xPosition = 2;
        public static int amountOfSteps = 10;
        private Random rnd = new Random();
        public static object locker = new object();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        static char winner;

        public void Start()
        {
            Task t1 = new Task(() =>
            {
                Bug bug1 = new Bug('&', 1);
                while (true)
                {
                    Movement<Bug>(bug1);
                }
            }, cancellationTokenSource.Token);

            Task t2 = Task.Run(() =>
            {
                Bug bug2 = new Bug('$', 3);
                while (true)
                {
                    Movement<Bug>(bug2);
                }
            }, cancellationTokenSource.Token);

            Task t3 = Task.Run(() =>
            {
                Bug bug3 = new Bug('#', 5);
                while (true)
                {
                    Movement<Bug>(bug3);
                }
            }, cancellationTokenSource.Token);

            Task t4 = Task.Run(() =>
            {
                Bug bug4 = new Bug('^', 7);
                while (true)
                {
                    Movement<Bug>(bug4);
                }
            }, cancellationTokenSource.Token);

            t1.Start();

            UI.FinishLine();
            UI.Summary();
        }

        public void Movement <T> (T instance) where T: Bug
        {
            if (!cancellationTokenSource.IsCancellationRequested)
            {
                lock(locker)
                {
                    instance.Move();
                    instance.ClearTail();
                }
                Thread.Sleep(rnd.Next(1000, 2000));
            }
            else if (instance.HorizontPos == amountOfSteps + xPosition)
            {
                winner = instance._symbol;
                cancellationTokenSource.Cancel();
            }
        }
    }
}
