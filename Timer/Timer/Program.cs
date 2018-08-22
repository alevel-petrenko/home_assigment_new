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
            Refrigerator refrigerator = new Refrigerator();
            AC aC = new AC();
            TimerClass.myTimerDelegate myTimer;
            TimerClass timerClass = new TimerClass(30);

            myTimer = refrigerator.TurnOn;
            myTimer += aC.TurnOn;

            timerClass.ShowAlarmTime();
            timerClass.Counter();

            while (true)
            {
                timerClass.ShowCurrentTime();
            }
        }
    }
}
