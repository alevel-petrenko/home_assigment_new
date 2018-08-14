using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Basket.Classes
{
    abstract class Player
    {
        public string Name { get; set; }
        abstract public int ChooseNumber();
    }

    static class StaticValues
    {
        public static List<int> bankOfAnswers = new List<int>();
        public static readonly int minValue = 40;
        public static readonly int maxValue = 60;
    }
}