using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Refrigerator refrigerator = new Refrigerator();
            AC aC = new AC();
            TimerClass timerClass = new TimerClass(59);

            timerClass.OnAlarm += refrigerator.TurnOn;
            timerClass.OnAlarm += aC.TurnOn;

            timerClass.ShowAlarmTime();
            timerClass.Counter();

            while (true)
            {
                timerClass.ShowCurrentTime();
            }
        }
    }
}
