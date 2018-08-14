using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Uber_Cheater_Player : Player
    {
        public Uber_Cheater_Player(string name)
        {
            Name = name;
        }

        private int answer = 40;
        public override int ChooseNumber()
        {
            while (StaticValues.bankOfAnswers.Contains(answer))
            {
                answer++;
            }

            Console.WriteLine($"Uber_Cheater_Player {Name} answered: {answer}\n");
            return answer;
        }
    }
}
