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

        static int seconds = 0;
        static int minutes = 0;
        static int hours = 0;

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
                    Thread.Sleep(300);
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
            ConvertToClockView();
            DisplayTime();
            //Console.SetCursorPosition(0, 0);
        }

        public void ShowAlarmTime()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Alarm timer is:");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine(_alarmTime);
        }

        private void ConvertToClockView ()
        {
            if (_currentTime < 60)
                seconds = _currentTime;
            else if (_currentTime >= 60)
            {            
                if (_currentTime % 60 >= 1)
                {
                    minutes++;
                }
                else if (_currentTime % 3600 == 0)
                {
                    minutes = 0;
                    hours++;
                }
                seconds = _currentTime - (minutes * 60);
            }
        }

        public void DisplayTime ()
        {
            string timeFormat = "";
            if (seconds < 10 && minutes == 0 && hours == 0)
                timeFormat = $"00:00:0{seconds}";
            else if(seconds >= 10 && minutes == 0 && hours == 0)
                timeFormat = $"00:00:{seconds}";
            else if (seconds < 10 && minutes > 0 && minutes < 10)
                timeFormat = $"00:0{minutes}:0{seconds}";
            else if (seconds >= 10 && minutes > 0 && minutes < 10)
                timeFormat = $"00:0{minutes}:{seconds}";
            else if (seconds < 10 && minutes >= 10)
                timeFormat = $"00:{minutes}:0{seconds}";
            else if (seconds >= 10 && minutes >= 10)
                timeFormat = $"00:{minutes}:{seconds}";

                Console.WriteLine(timeFormat);
        }
    }
}
