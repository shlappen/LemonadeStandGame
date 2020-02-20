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
        Store store;

        public Game()
        {
            store = new Store();
            currentDay = 0;
            player = new Player();
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

        public void RunWeek()
        {
            do
            {
                RunDay();
                currentDay++;
                Console.WriteLine();
            } while (currentDay <= 6);
            Console.WriteLine("Thank you for playing!");
        }

        public void RunDay()
        {
            Console.WriteLine("Hi " + player.name);
            day = days[currentDay];
            day.weather = new Weather(0, "");
            day.weather.condition = day.weather.SetWeatherCondition();
            day.weather.temperature = day.weather.SetTemperature();
            Console.WriteLine("Day {0}: {1}", currentDay + 1, days[currentDay].name);
            Console.WriteLine("Forecast: {1} degrees and {0}", day.weather.condition, day.weather.temperature);
            Console.WriteLine();
            player.GoToStore(store, player);
            if(currentDay < 1)
            {
                player.SetRecipe(day);
            }
            else
            {
                player.SetPricePerCup(day);

            }
            day.SetDemand(player);
        }

        public void RunGame()
        {
            Console.WriteLine("Welcome to your Lemonade Stand");
            Console.WriteLine();
            UserInterface.DisplayRules();
            Console.WriteLine();
            player.name = UserInterface.SetPlayerName();
            Console.WriteLine();
            RunWeek();
        }
    }
}
