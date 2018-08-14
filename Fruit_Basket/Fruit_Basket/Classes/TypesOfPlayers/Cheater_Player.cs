using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Cheater_Player : Player
    {
        public Cheater_Player(string name)
        {
            Name = name;
        }

        private Random rndForPlayers = new Random();

        public override int ChooseNumber()
        {
            int nextAnswer;
            do
            {
                nextAnswer = rndForPlayers.Next(StaticValues.minValue, StaticValues.maxValue);
            }
            while (StaticValues.bankOfAnswers.Contains(nextAnswer));

            Console.Write($"Cheater_Player {Name} answered: {nextAnswer}\n");
            return nextAnswer;
        }
    }
}
