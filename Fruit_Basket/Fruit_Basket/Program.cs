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
            int amountOfPlayers = 0;
            //initializing weight of the basket
            int basketWeight = rndForBasket.Next(40, 140);

            Console.WriteLine($"welcome to our lottery!!!\n"+
            "How many players do you want?");

            //number of players in our lottery
            if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    amountOfPlayers = number;
                }

            //creating these players for game
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.Write($"Pick up the type of player\n" +
                    $"1 - Usuall_Player\n" +
                    $"2 - Player_Notebook\n" +
                    $"3 - Uber_Player\n" +
                    $"4 - Cheater_Player\n" +
                    $"5 - Uber_Cheater_Player\n");
                int choise = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();

                switch (choise)
                {
                    case 1:
                        Usuall_Player US = new Usuall_Player(name);
                        allPlayers.Add(US);
                        Console.WriteLine($"Player {name} has been created!");
                        break;
                    case 2:
                        Player_Notebook PN = new Player_Notebook(name);
                        allPlayers.Add(PN);
                        Console.WriteLine($"Player {name} has been created!");
                        return;
                    case 3:
                        Uber_Player UP = new Uber_Player(name);
                        allPlayers.Add(UP);
                        Console.WriteLine($"Player {name} has been created!");
                        break;
                    case 4:
                        Cheater_Player CP = new Cheater_Player(name);
                        allPlayers.Add(CP);
                        Console.WriteLine($"Player {name} has been created!");
                        break;
                    case 5:
                        Uber_Cheater_Player UCP = new Uber_Cheater_Player(name);
                        allPlayers.Add(UCP);
                        Console.WriteLine($"Player {name} has been created!");
                        break;
                }
                Console.Clear();
            }

            Console.WriteLine($"The real basket weight is {basketWeight}" +
                $"The game has began ...");

            int counter = 0;
            do
            {
                foreach (var player in allPlayers)
                {
                    Thread.Sleep(50);
                    BankOfAnswers.bankOfAnswers.Add(player.ChooseNumber());
                    counter++;
                }
            }
            while (counter < 101);

        }
    }
}
