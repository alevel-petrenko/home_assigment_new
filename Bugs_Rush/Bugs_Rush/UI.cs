using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs_Rush
{
    class UI
    {
        public void Start()
        {
            FinishLine();
            Summary();
        }

        private void FinishLine ()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < 9; i++)
            {
                {
                    Console.SetCursorPosition(Logic.XPositionStart+Logic.AmountOfSteps-1, i);
                    Console.Write('|');
                }
            }
            Console.ResetColor();
        }

        private void Summary()
        {
            Console.SetCursorPosition(Logic.XPositionStart + Logic.AmountOfSteps + 5, 1);
            Console.Write("Rush of Cockroaches");
        }
        
        public void Winner (char winner)
        {
            Console.SetCursorPosition(Logic.XPositionStart + Logic.AmountOfSteps + 5, 3);
            Console.Write($"The winner is {winner}");
        }
    }
}
