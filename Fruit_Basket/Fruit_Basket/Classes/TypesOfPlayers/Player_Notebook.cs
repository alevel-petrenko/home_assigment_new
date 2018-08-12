using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Player_Notebook : Player
    {
        Random rndForPlayers = new Random();
        List<int> allAnswers = new List<int>();

        public Player_Notebook(string name)
        {
            Name = name;
        }

        public override int ChooseNumber()
        {
            int nextAnswer;
            do
            {
                nextAnswer = rndForPlayers.Next(40, 140);
            }
            while (allAnswers.Contains(nextAnswer));

            Console.Write("Player_Notebook answered: ");
            return nextAnswer;
        }
    }
}
