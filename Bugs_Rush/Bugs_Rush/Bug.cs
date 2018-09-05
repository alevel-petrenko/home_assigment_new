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
        public int VerticalPos { get; set; }
        public int HorizontPos { get; set; } = Logic.xPosition;
        private readonly char _symbol;

        public Bug(char symbol, int x)
        {
            _symbol = symbol;
            VerticalPos = x;
        }

        public void Move ()
        {
            Console.SetCursorPosition(HorizontPos, VerticalPos);
            Console.Write(_symbol);
            MakeStep();
        }

        private void MakeStep()
        {
            HorizontPos++;
        }

        public void ClearTail ()
        {
            Console.SetCursorPosition(HorizontPos - 1, VerticalPos);
            Console.Write(" ");
        }
    }
}
