using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Usuall_Player : Player
    {
        Random rndForPlayers = new Random();

        public Usuall_Player(string name)
        {
            Name = name;
        }

        public override int ChooseNumber()
        {
            Console.Write("Usuall_Player answered: ");
            return rndForPlayers.Next (40,140);
        }
    }
}
