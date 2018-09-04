using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    static class UI
    {
        public static int lineY;
        public static void FinishLine ()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(lineY+i, 1);
                Console.Write('|');
            }
        }
    }
}
