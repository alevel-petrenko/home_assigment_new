using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Uber_Player : Player
    {
        private byte answer = 40;
        public override int ChooseNumber()
        {
            Console.WriteLine("Player_Uber answered: ");
            return answer++;
        }
    }
}
