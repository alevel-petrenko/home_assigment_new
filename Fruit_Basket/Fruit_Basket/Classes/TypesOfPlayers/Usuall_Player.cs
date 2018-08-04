using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Usuall_Player : Player
    {
        public override int ChosenNumber()
        {
            Random rndForPlayers = new Random();
            Console.WriteLine("Usuall_Player answered:");
            return rndForPlayers.Next (40,140);
        }
    }
}
