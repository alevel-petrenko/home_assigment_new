using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fruit_Basket.Classes.TypesOfPlayers;

namespace Fruit_Basket
{
    class Program
    {
        //Цель игры угадать вес корзины с фруктами.Вес корзины находится в диапазоне от 40 до 140 кг.

        //Правила
        //Игра заканчивается когда один игрок угадал вес корзины или все игроки вместе сделали 100 попыток
        
        //Типы игроков:      
        //Обычный игрок – угадывает числа случайно.Никакой логики, никаких зависимостей
        //Игрок-блокнот – также угадывает случайно, но не повторяет один и тот же выбор дважды
        //Убер-игрок - идет по порядку, 40, 41, 42, 43…
        //Читер – угадывает числа случайно, но не пробует варианты которые не получились у остальных игроков
        //Убер-читер – идет по порядку, но пропускает опробованные другими игроками варианты

        //Входные данные:
        //Игроки, от 2 до 8. Каждому игроку имя и тип

        //Вывод:
        //В начале игры – реальный вес корзины
        //В конце победитель.Если после 100 попыток победителя нет – тот игрок, что
        //наиболее близко угадал вес.

        static void Main(string[] args)
        {
            Random rndForBasket = new Random();
            byte basketWeight = (byte)rndForBasket.Next(40, 140);
            Console.WriteLine($"The real basket weight is {basketWeight}");

            Usuall_Player US = new Usuall_Player();
            Player_Notebook PN = new Player_Notebook();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(US.ChosenNumber());
                Console.WriteLine(PN.ChosenNumber()); 
            }
        }
    }
}
