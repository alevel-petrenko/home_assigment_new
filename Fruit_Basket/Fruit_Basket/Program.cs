using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fruit_Basket.Classes;
using Fruit_Basket.Classes.TypesOfPlayers;
using System.Threading;

namespace Fruit_Basket
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfPlayers = 0;
            do
            {
                Console.WriteLine($"Welcome to our lottery!!!\n" +
                "How many players do you want?");

                //number of players in our lottery
                if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    amountOfPlayers = number;
                }
            }
            while (amountOfPlayers == 0);

            Game game = new Game();
            game.CreatePlayers(amountOfPlayers);
            game.GameStart();
        }
    }
}
