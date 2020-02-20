using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public string name;
        public Random random;
        public int purchases;
        public int demandModifier;

        public Day(string name)
        {
            purchases = 0;
            random = new Random();
            weather = null;
            this.name = name;
            customers = new List<Customer>
            {
                new Customer ("Old Thirsty Jackson"),
                new Customer ("Freshly Squeezed Prince of Bel Air"),
                new Customer ("Parchy McParchedface"),
                new Customer ("Kid who ate bag of pretzels"),
                new Customer ("Lil Big Gulp"),
                new Customer ("Todd"),
                new Customer ("Jimmy Two Cups"),
                new Customer ("Guy who always asks for free refill"),
                new Customer ("General George Washitdown"),
                new Customer ("Baby Sips"),
                new Customer ("Steve 'Always Brings A Straw' Peterson "),
                new Customer ("Customer whose name you forgot"),
                new Customer ("The lemonade drinker formerly known as Prince"),
                new Customer ("Chronically Dehydrated Sandra"),
                new Customer ("Baron Von Drytonsils"),
                new Customer ("Dr. Orangina Julius"),
                new Customer ("Stephanie McWoman"),
                new Customer ("Elizabeth Lemon"),
                new Customer ("Vlad the Imbiber"),
                new Customer ("Todd's thirstier older brother")
            };
        }


        public void SetDemand(Player player)
        {
            SetBaseMaxWillingToPay();
            if (player.recipe.amountOfLemons >= 5 || player.recipe.amountOfSugarCubes >= 5)
            {
                demandModifier += 3;
            }
            if (weather.temperature >= 70)
            {
                demandModifier += 3;
            }
            if (weather.temperature >= 90)
            {
                demandModifier += 3;
            }
            if (weather.condition == "Sunny")
            {
                demandModifier += 1;
                if (weather.temperature >= 90 && weather.condition == "Sunny")
                {
                    demandModifier += 3;
                }
            }
            if (weather.condition == "Rainy")
            {
                demandModifier = 1;
            }
            if (weather.condition == "Cloudy")
            {
                demandModifier = 1;
            }
            
        }

        public void SetBaseMaxWillingToPay()
        {
            for (int j = 0; j < customers.Count; j++)
            {
                int i = random.Next(1, 3);
                customers[j].maxWillingToPay = i;
            }
        }

        public void SpoilLemonsLeftInPitcher(Player player)
        {
            if (purchases >= 4 && (player.inventory.lemons.Count < player.recipe.amountOfLemons))
            {
                int remainder = purchases % 4;
                player.inventory.lemons.RemoveRange(0, remainder);
                Console.WriteLine("{0} of your lemons spoiled!", remainder);
            };
        }
    }
}
