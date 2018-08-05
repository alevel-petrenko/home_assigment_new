using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fruit_Basket.Classes;
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Random rndForBasket = new Random();
            List<Player> allPlayers = new List<Player>();

            byte basketWeight = (byte)rndForBasket.Next(40, 140);
            Console.WriteLine($"The real basket weight is {basketWeight}");

            Usuall_Player US = new Usuall_Player();
            Player_Notebook PN = new Player_Notebook();
            Uber_Player UP = new Uber_Player();
            Cheater_Player CP = new Cheater_Player();
            Uber_Cheater_Player UCP = new Uber_Cheater_Player();

            allPlayers.Add(US);
            allPlayers.Add(PN);
            allPlayers.Add(UP);
            allPlayers.Add(CP);
            allPlayers.Add(UCP);

            for (int i = 0; i < 50; i++)
            {
                foreach (var player in allPlayers)
                {
                    BankOfAnswers.bankOfAnswers.Add(player.ChooseNumber());
                }
            }

        }
    }
}
