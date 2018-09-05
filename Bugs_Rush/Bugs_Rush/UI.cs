using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    static class UI
    {
        static public void FinishLine ()
        {
            for (int i = 0; i < 8; i++)
            {
                {
                    Console.SetCursorPosition(Logic.xPosition+Logic.amountOfSteps-1, i);
                    Console.Write('|');
                }
            }
        }

        static public void Summary ()
        {
            Console.SetCursorPosition(Logic.xPosition + Logic.amountOfSteps + 5, 0);
            Console.Write("Rush of Cockroaches");
            Console.SetCursorPosition(Logic.xPosition + Logic.amountOfSteps + 5, 3);
            Console.Write("The winner is {}");
        }
    }
}
