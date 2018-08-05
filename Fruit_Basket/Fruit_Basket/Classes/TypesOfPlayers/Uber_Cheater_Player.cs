using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes.TypesOfPlayers
{
    class Uber_Cheater_Player : Player
    {
        private byte answer = 40;
        public override int ChooseNumber()
        {
            while (BankOfAnswers.bankOfAnswers.Contains(answer))
                answer++;

            Console.WriteLine("Uber_Cheater_Player answered: ");
            return answer++;
        }
    }
}
