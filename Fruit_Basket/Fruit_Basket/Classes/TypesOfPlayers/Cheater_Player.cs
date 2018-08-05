using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Cheater_Player : Player
    {
        Random rndForPlayers = new Random();

        public override int ChooseNumber()
        {
            int nextAnswer;
            do
            {
                nextAnswer = rndForPlayers.Next(40, 140);
            }
            while (BankOfAnswers.bankOfAnswers.Contains(nextAnswer));

            Console.Write("Cheater_Player answered: ");
            return nextAnswer;
        }
    }
}
