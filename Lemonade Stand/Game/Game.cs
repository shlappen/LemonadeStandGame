using System;
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
        
        public Game()
        {
            currentDay = 0;
            player = new Player();
            days = new List<Day>
            {   new Day("Monday"),
                new Day("Tuesday"),
                new Day("Wednesday"),
                new Day("Thursdsay"),
                new Day("Friday"),
                new Day("Saturday"),
                new Day("Sunday"),
            };
        }

        public void DisplayRules()
        {
            Console.WriteLine("Your goal is to make as much money as you can in 7, 14, or 30 days by selling lemonade at your lemonade stand. " +
                "Buy cups, lemons, sugar, and ice cubes, then set your recipe based on the weather and conditions. " +
                "Start with the basic recipe, but try to vary the recipe and see if you can do better. " +
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
            day = days[currentDay];
            day.weather = new Weather(0, "");
            day.weather.condition = day.weather.SetWeatherCondition();
            day.weather.temperature = day.weather.SetTemperature();
            currentDay++;
            Console.WriteLine("Day 1: {0}", days[currentDay].name);
            Console.WriteLine("Forecast: {1} degrees and {0}", day.weather.condition, day.weather.temperature);

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
