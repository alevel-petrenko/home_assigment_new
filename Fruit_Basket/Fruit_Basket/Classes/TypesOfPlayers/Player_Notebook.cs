using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Player_Notebook : Player

    {
        public override int ChosenNumber()
        {
            Random rndForPlayers = new Random();
            int nextAnswer;
            List<int> allAnswers = new List<int>();

            do
            {
                nextAnswer = rndForPlayers.Next(40, 140);
            }
            while (allAnswers.Contains(nextAnswer));

            Console.WriteLine("Player_Notebook answered:");

            return nextAnswer;
        }
    }
}
