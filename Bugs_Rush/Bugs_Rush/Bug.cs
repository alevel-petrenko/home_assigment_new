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
        public char _symbol;

        public Bug(char symbol, int x)
        {
            _symbol = symbol;
            VerticalPos = x;
        }

        public void Move ()
        {
            DrawBug();
            ClearTail();
            MakeStep();
        }

        private void DrawBug ()
        {
            Console.SetCursorPosition(HorizontPos, VerticalPos);
            Console.Write(_symbol);
        }

        private void MakeStep()
        {
            HorizontPos++;
        }

        private void ClearTail()
        {
            Console.SetCursorPosition(HorizontPos - 1, VerticalPos);
            Console.Write(" ");
        }
    }
}
