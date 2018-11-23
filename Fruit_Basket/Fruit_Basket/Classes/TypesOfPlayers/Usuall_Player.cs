using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Usuall_Player : Player
    {
        private Random rndForPlayers = new Random();

        public Usuall_Player(string name)
        {
            Name = name;
        }

        public override int ChooseNumber()
        {
            int choise = rndForPlayers.Next(StaticValues.minValue, StaticValues.maxValue);
            Console.Write($"Usuall_Player {Name} answered: {choise}\n");
            return choise;
        }
    }
}
