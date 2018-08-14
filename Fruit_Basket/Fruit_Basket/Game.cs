using Fruit_Basket.Classes;
using System;
using System.Collections.Generic;
using Fruit_Basket.Classes.TypesOfPlayers;
using System.Threading;

namespace Fruit_Basket
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

    class Game
    {
        private Random rndForBasket = new Random();
        private List<Player> allPlayers = new List<Player>();
        private int basketWeight = 0;
        private Player winner;        

        public Game()
        {
            //initializing weight of the basket
            basketWeight = rndForBasket.Next(StaticValues.minValue, StaticValues.maxValue);
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public void CreatePlayers (int numberOfPlayers)
        {
            //creating these players for game
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"" +
                    $"1 - Usuall_Player\n" +
                    $"2 - Player_Notebook\n" +
                    $"3 - Uber_Player\n" +
                    $"4 - Cheater_Player\n" +
                    $"5 - Uber_Cheater_Player\n" +
                    $"Pick up the type. Enter the number of player\n");
                int choise = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please enter player's name");
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
                        break;
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
            }
            Thread.Sleep(150);
            Console.Clear();
        }

        public void GameStart ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The real basket weight is {basketWeight}\n" +
                $"The game has began ... \n");

            //counter for 100 steps
            int counter = 0;

            while (counter < 101 && !StaticValues.bankOfAnswers.Contains(basketWeight))
            {
                foreach (var player in allPlayers)
                {
                    Thread.Sleep(100);
                    StaticValues.bankOfAnswers.Add(player.ChooseNumber());
                    winner = player;
                    counter++;
                }
            }
            
            if (StaticValues.bankOfAnswers.Contains(basketWeight))
            {
                Console.WriteLine($"The winner is {winner.Name}");
            }
        }
    }
}
