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
        Random random;

        public Day(string name)
        {
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
                new Customer ("Vlad the Imbiber"),
                new Customer ("Jimmy 'Two Cups' Romano"),
                new Customer ("Guy who always asks for free refill"),
                new Customer ("General George Washitdown"),
                new Customer ("Baby Sips"),
                new Customer ("Steve 'Always Brings A Straw' Peterson "),
                new Customer ("Parched Zombie Prince"),
                new Customer ("The lemonade drinker formerly known as Prince"),
                new Customer ("Chronically Dehydrated Sandra"),
                new Customer ("Baron Von Drytonsils"),
                new Customer ("Dr. Orangina Julius"),
                new Customer ("Stephanie McWoman"),
                new Customer ("Elizabeth Lemon"),
                new Customer ("Todd"),
                new Customer ("Todd's thirstier older brother")
            };
        }
        public void SetBaseMaxWillingToPay()
        {
            for (int j = 0; j < customers.Count; j++)
            {
                double i = random.Next(1, 5);
                customers[j].maxWillingToPay = i / 2;
            }
        }

        public void SetDemand(Player player)
        {
            SetBaseMaxWillingToPay();
            int demandModifier = 2;
            if (weather.temperature >= 70)
            {
                demandModifier += 1;
            }
            if (weather.temperature >= 90)
            {
                demandModifier += 1;
            }
            if (weather.condition == "Sunny")
            {
                demandModifier += 2;
                if (weather.temperature >= 90 && weather.condition == "Sunny")
                {
                    demandModifier += 1;
                }
            }
            if (weather.condition == "Rainy")
            {
                demandModifier -= 2;
            }
            if (weather.condition == "Cloudy")
            {
                demandModifier -= 1;
            }
            SellLemonade(demandModifier, player);
        }
        public void SellLemonade(int demandModifier, Player player)
        {
            double purchases = 0;
            double i = random.Next(demandModifier, 21);
            for (int j = 0; j < i; j++)
            {
                customers[j].willBuy = true;
                customers[j].maxWillingToPay += demandModifier / 2;

                if ((player.recipe.PricePerCup <= customers[j].maxWillingToPay)
                    && (customers[j].willBuy = true)
                                && (player.inventory.lemons.Count >= player.recipe.amountOfLemons)
                                && (player.inventory.sugarCubes.Count >= player.recipe.amountOfSugarCubes)
                                && (player.inventory.iceCubes.Count >= player.recipe.amountOfIceCubes)
                                        && (player.inventory.cups.Count > 0))
                {
                    player.inventory.cups.RemoveAt(0);
                    player.inventory.iceCubes.RemoveRange(0, player.recipe.amountOfIceCubes);
                    purchases++;
                    //this is the stand-in for the pitcher: pitcher can hold 4 cups
                    if (purchases > 0)
                    {
                        if (purchases % 4 == 0)
                        {
                            player.inventory.lemons.RemoveRange(0, player.recipe.amountOfLemons);
                            player.inventory.sugarCubes.RemoveRange(0, player.recipe.amountOfSugarCubes);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine(customers[j].name + " purchased a lemonade!");
                }
            }
            if (purchases > 0 && purchases < 4)
            {
                player.inventory.lemons.RemoveRange(0, player.recipe.amountOfLemons);
                player.inventory.sugarCubes.RemoveRange(0, player.recipe.amountOfSugarCubes);
            }
            else
            {
                    Spoil(purchases);
            }

            UserInterface.NotEnoughInventoryCheck(player);
            player.wallet.ReceiveMoneyFromCustomers(player, purchases);
        }

        public void Spoil(double purchases)
        {
            if (purchases > 0)
            {
                double spoilAmount = purchases % 4;
            }
        }
    }
}
