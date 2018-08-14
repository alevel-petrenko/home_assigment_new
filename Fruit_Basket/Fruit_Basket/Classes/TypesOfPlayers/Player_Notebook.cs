using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Player_Notebook : Player
    {
        private Random rndForPlayers = new Random();
        private List<int> allAnswers = new List<int>();

        public Player_Notebook(string name)
        {
            Name = name;
        }

        public override int ChooseNumber()
        {
            int nextAnswer;
            do
            {
                nextAnswer = rndForPlayers.Next(StaticValues.minValue, StaticValues.maxValue);
            }
            while (allAnswers.Contains(nextAnswer));

            Console.Write($"Player_Notebook {Name} answered: {nextAnswer}\n");
            return nextAnswer;
        }
    }
}
