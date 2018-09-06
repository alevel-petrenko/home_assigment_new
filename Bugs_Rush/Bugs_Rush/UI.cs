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
            for (int i = 0; i < 8; i++)
            {
                {
                    Console.SetCursorPosition(Logic.xPosition+Logic.amountOfSteps-1, i);
                    Console.Write('|');
                }
            }
        }

        private void Summary ()
        {
            Console.SetCursorPosition(Logic.xPosition + Logic.amountOfSteps + 5, 1);
            Console.Write("Rush of Cockroaches");
            Console.SetCursorPosition(Logic.xPosition + Logic.amountOfSteps + 5, 3);
            Console.Write($"The winner is {Logic.winner}");
        }
    }
}
