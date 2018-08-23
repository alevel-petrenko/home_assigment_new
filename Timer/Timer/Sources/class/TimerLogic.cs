using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer.Sources
{
    class TimerLogic
    {
        private int seconds;
        private int minutes;
        private int hours;

        //public void ConvertToClockView(int _someTime)
        //{
        //    if (_someTime < 60)
        //        seconds = _someTime;
        //    else if (_someTime >= 60)
        //    {
        //        if (_someTime % 60 == 0)
        //        {
        //            minutes++;
        //            seconds++;
        //        }
        //        else if (_someTime % 3600 == 0)
        //        {
        //            seconds++;
        //            minutes = 0;
        //            hours++;
        //            seconds = _someTime - hours * 3600;
        //        }
        //        seconds = _someTime - minutes * 60;
        //    }
        //}

        public void DisplayTime()
        {
            string timeFormat = "";
            if (seconds < 10 && minutes == 0 && hours == 0)
                timeFormat = $"00:00:0{seconds}";
            else if (seconds >= 10 && minutes == 0 && hours == 0)
                timeFormat = $"00:00:{seconds}";
            else if (seconds < 10 && minutes > 0 && minutes < 10)
                timeFormat = $"00:0{minutes}:0{seconds}";
            else if (seconds >= 10 && minutes > 0 && minutes < 10)
                timeFormat = $"00:0{minutes}:{seconds}";
            else if (seconds < 10 && minutes >= 10)
                timeFormat = $"00:{minutes}:0{seconds}";
            else if (seconds >= 10 && minutes >= 10)
                timeFormat = $"00:{minutes}:{seconds}";

            Console.Write($"{timeFormat}\n");
        }

        public void Converter(int number)
        {
            if (number/60 <= 0)
            {
                seconds = number;
            }
            else if (number / 60 > 0)
            {
                minutes = number / 60;
                seconds = number - minutes * 60;
            }
            else if (number / 3600 > 0)
            {
                hours = number / 3600;
                minutes = number - hours * 3600;
                seconds = number - minutes * 60;
            }
        }
    }
}
