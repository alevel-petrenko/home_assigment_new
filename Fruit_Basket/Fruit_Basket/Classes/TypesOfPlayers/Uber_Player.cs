using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Uber_Player : Player
    {
        public Uber_Player(string name)
        {
            Name = name;
        }

        private int answer = 40;
        public override int ChooseNumber()
        {
            Console.WriteLine($"Player_Uber {Name} answered: {answer++}\n");
            return answer;
        }
    }
}
