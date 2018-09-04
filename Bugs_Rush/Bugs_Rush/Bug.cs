using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    class Bug
    {
        public static object obj = new object();
        private int _xPos;
        private int _yPos;
        private readonly char _symbol;
        private Random rnd = new Random();

        public Bug(char symbol, int x, int y)
        {
            _symbol = symbol;
            _xPos = x;
            _yPos = UI.lineY = y;
        }

        public void Move()
        {
            int i = 0;
            while (i<10)
            {
                Thread.Sleep(rnd.Next(500, 1000));
                Step();
                lock (obj)
                {
                    Console.SetCursorPosition(_yPos, _xPos);
                    Console.Write(_symbol);
                    ClearPrint();
                }
            }
            i++;
        }

        private void Step ()
        {
            _yPos++;
        }

        private void ClearPrint ()
        {
            Console.SetCursorPosition(_yPos - 1, _xPos);
            Console.Write(" ");
        }
    }
}
