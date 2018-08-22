using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    class TimerClass : ITimer
    {
        public delegate void myTimerDelegate ();
        public event myTimerDelegate OnAlarm;

        private int _currentTime;
        private int _alarmTime;

        public TimerClass(int alarmTime)
        {
            _currentTime = 0;
            SetAlarm(alarmTime);
        }

        public void Counter()
        {
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //Sleep for one second
                    Thread.Sleep(1000);
                    //And increment our inner counter
                    _currentTime += 1;

                    if (_alarmTime == _currentTime) OnAlarm?.Invoke();
                } while (true);
            });
        }

        public void SetAlarm(int minutes)
        {
            _alarmTime = minutes;
        }

        public void ShowCurrentTime()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Current time is:");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine(_currentTime);
        }

        public void ShowAlarmTime()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Alarm timer is:");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine(_alarmTime);
        }
    }

}
