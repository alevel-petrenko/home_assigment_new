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
        private int _currentTime;
        private int _alarmTime;

        private void Counter()
        {
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //Sleep for one second
                    Thread.Sleep(1000);
                    //And increment our inner counter
                    _currentTime += 1;

                    //if (_alarmTime == _currentTime) OnAlarm?.Invoke();
                } while (true);
            });
        }
    }
}
