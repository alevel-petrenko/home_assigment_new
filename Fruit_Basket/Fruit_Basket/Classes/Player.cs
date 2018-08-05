using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes
{
    abstract class Player
    {
        abstract public int ChooseNumber();
    }

    static class BankOfAnswers
    {
        public static List<int> bankOfAnswers = new List<int>();
    }
}
