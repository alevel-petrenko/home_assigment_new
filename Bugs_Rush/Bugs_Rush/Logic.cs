using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    class Logic
    {
        public static int XPositionStart = 2;
        public static int AmountOfSteps = 10;
        private int _amountOfCockroaches = 3;
        private UI _uI = new UI();
        private Random _rnd = new Random();
        private static object _locker = new object();
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        List<Task> cockroaches = new List<Task>();

        public void Start()
        {
            int _counterForXLoc = 1;
            char[] arrayOfSymbols = new char[4] { 'O', 'Ж', '%', '$' };

            for (int i = 0; i < _amountOfCockroaches; i++)
            {
                cockroaches.Add(Task.Run(() =>
                    {
                        Bug bug = new Bug(arrayOfSymbols[i], _counterForXLoc);
                        while (!_cancellationTokenSource.IsCancellationRequested)
                        {
                            Thread.Sleep(50);
                            Movement<Bug>(bug);
                        }
                    }, _cancellationTokenSource.Token));
                _counterForXLoc += 2;
            }
        }

        public void Movement <T> (T instance) where T: Bug
        {
            if (instance.HorizontPos != AmountOfSteps + XPositionStart)
            {
                lock(_locker)
                {
                    instance.Move();
                }
                Thread.Sleep(_rnd.Next(500, 1000));
            }
            else if (instance.HorizontPos == AmountOfSteps + XPositionStart)
            {
                _uI.Winner(instance._symbol);
                _cancellationTokenSource.Cancel();
            }
        }
    }
}

//Task t1 = Task.Run(() =>
//{
//    Bug bug = new Bug('&', 1);
//    while (!_cancellationTokenSource.IsCancellationRequested)
//    {
//        Thread.Sleep(50);
//        Movement<Bug>(bug);
//    }
//}, _cancellationTokenSource.Token);

//Task t2 = Task.Run(() =>
//{
//    Bug bug2 = new Bug('$', 3);
//    while (!_cancellationTokenSource.IsCancellationRequested)
//    {
//        Thread.Sleep(50);
//        Movement<Bug>(bug2);
//    }
//}, _cancellationTokenSource.Token);

//Task t3 = Task.Run(() =>
//{
//    Bug bug3 = new Bug('#', 5);
//    while (!_cancellationTokenSource.IsCancellationRequested)
//    {
//        Thread.Sleep(50);
//        Movement<Bug>(bug3);
//    }
//}, _cancellationTokenSource.Token);

//Task t4 = Task.Run(() =>
//{
//    Bug bug4 = new Bug('^', 7);
//    while (!_cancellationTokenSource.IsCancellationRequested)
//    {
//        Thread.Sleep(50);
//        Movement<Bug>(bug4);
//    }
//}, _cancellationTokenSource.Token);
