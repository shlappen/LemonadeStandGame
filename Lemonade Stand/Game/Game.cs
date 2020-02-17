﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        Player player;
        List<Day> days;
        int currentDay;
        Day day;
        Store store;
        
        public Game()
        {
            currentDay = 0;
            player = new Player();
            store = new Store();
            days = new List<Day>
            {   new Day("Monday"),
                new Day("Tuesday"),
                new Day("Wednesday"),
                new Day("Thursday"),
                new Day("Friday"),
                new Day("Saturday"),
                new Day("Sunday"),
            };
        }

        public void DisplayRules()
        {
            Console.WriteLine("Your goal is to make as much money as you can in 7 days by selling lemonade at your lemonade stand. " +
                "Buy cups, lemons, sugar, and ice cubes, then set your recipe based on the weather and conditions. " +
                "Lastly, set your price and sell your lemonade at the stand. " +
                "Try changing up the price based on the weather conditions as well. At the end of the game, you'll see how much money you made. " +
                "Write it down and play again to try and beat your score!");
        }

        public void SetPlayerName()
        {
            Console.WriteLine("Please enter your name");
            player.name = Console.ReadLine();
        }


        public void RunWeek()
        {
            Console.WriteLine("Hi " + player.name);
            day = days[currentDay];
            day.weather = new Weather(0, "");
            day.weather.condition = day.weather.SetWeatherCondition();
            day.weather.temperature = day.weather.SetTemperature();
            currentDay++;
            Console.WriteLine("Day {0}: {1}", currentDay, days[currentDay].name);
            Console.WriteLine("Forecast: {1} degrees and {0}", day.weather.condition, day.weather.temperature);
            Console.WriteLine();
            GoToStore();

        }

        public void GoToStore()
        {
            DisplayInventory();
            Console.WriteLine("Your money: ${0}", player.wallet.Money);
            Buy();
        }

        public void DisplayStoreOptions()
        {
                Console.WriteLine("Press 1 to buy lemons for 50 cents per lemon.");
                Console.WriteLine("Press 2 to buy sugarcubes for 10 cents per cube.");
                Console.WriteLine("Press 3 to buy ice cubes for 1 cent per cube.");
                Console.WriteLine("Press 4 to buy cups for 25 cents per cup.");
            Console.WriteLine("Press 5 to leave store.");
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Your inventory:");
            Console.WriteLine(player.inventory.lemons.Count + " Lemons");
            Console.WriteLine(player.inventory.sugarCubes.Count + " Sugar Cubes");
            Console.WriteLine(player.inventory.iceCubes.Count + " Ice Cubes");
            Console.WriteLine(player.inventory.cups.Count + " Cups");
            Console.WriteLine();
        }

        public void Buy()
        {
            DisplayStoreOptions();
            string input = Console.ReadLine();
            Console.WriteLine();
            bool isValid = false;
            do
            {
                switch (input)
                {
                    case "1":
                        store.SellLemons(player);
                        GoToStore();
                        isValid = true;
                        break;
                    case "2":
                        store.SellSugarCubes(player);
                        GoToStore();
                        isValid = true;
                        break;
                    case "3":
                        store.SellIceCubes(player);
                        GoToStore();
                        isValid = true;
                        break;
                    case "4":
                        store.SellCups(player);
                        GoToStore();
                        isValid = true;
                        break;
                    case "5":
                        isValid = true;
                        break;
                    default:
                        Buy();
                        isValid = true;
                        break;
                }
            } while (isValid == false);
            Console.WriteLine();
        }

        public void SetRecipe()
        {
            
        }

        public void RunGame()
        {
            Console.WriteLine("Welcome to your Lemonade Stand");
            Console.WriteLine();
            DisplayRules();
            Console.WriteLine();
            SetPlayerName();
            Console.WriteLine();
            RunWeek();
        
        }
    }
}
