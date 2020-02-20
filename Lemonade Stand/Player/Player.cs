using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public string name;
        //public Pitcher pitcher;
        public Recipe recipe;


        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            //pitcher = new Pitcher();
        }

        // member methods (CAN DO)

        public void DisplayInventory()
        {
            Console.WriteLine("Your inventory:");
            Console.WriteLine(inventory.lemons.Count + " Lemons");
            Console.WriteLine(inventory.sugarCubes.Count + " Sugar Cubes");
            Console.WriteLine(inventory.iceCubes.Count + " Ice Cubes");
            Console.WriteLine(inventory.cups.Count + " Cups");
            Console.WriteLine();
        }

        public void GoToStore(Store store, Player player)
        {
            DisplayInventory();
            wallet.DisplayMoney();
            BuySupplies(store, player);
        }

        public void BuySupplies(Store store, Player player)
        {
            UserInterface.DisplayStoreOptions();
            string input = Console.ReadLine();
            Console.WriteLine();
            bool isValid;
            do
            {
                switch (input)
                {
                    case "1":
                        store.SellLemons(player);
                        GoToStore(store, player);
                        isValid = true;
                        break;
                    case "2":
                        store.SellSugarCubes(player);
                        GoToStore(store, player);
                        isValid = true;
                        break;
                    case "3":
                        store.SellIceCubes(player);
                        GoToStore(store, player);
                        isValid = true;
                        break;
                    case "4":
                        store.SellCups(player);
                        GoToStore(store, player);
                        isValid = true;
                        break;
                    case "5":
                        isValid = true;
                        break;
                    default:
                        BuySupplies(store, player);
                        isValid = true;
                        break;
                }
            } while (isValid == false);
        }

        public void SetRecipe(Day day)
        {
            SetLemons(recipe);
            SetSugar(recipe);
            SetIce(recipe);
            SetPricePerCup(recipe, day);
        }

        public int SetLemons(Recipe recipe)
        {
            bool userInputIsAnInteger = false;
            while (!userInputIsAnInteger || recipe.amountOfLemons > inventory.lemons.Count)
            {
                Console.WriteLine("Please enter number of lemons per pitcher.");
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out recipe.amountOfLemons);
            }
            return recipe.amountOfLemons;
        }

        public int SetSugar(Recipe recipe)
        {
            bool userInputIsAnInteger = false;
            while (!userInputIsAnInteger || recipe.amountOfSugarCubes > inventory.sugarCubes.Count)
            {
                Console.WriteLine("Please enter the number of sugar cubes per pitcher.");
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out recipe.amountOfSugarCubes);
            }
            return recipe.amountOfSugarCubes;
        }

        public int SetIce(Recipe recipe)
        {
            bool userInputIsAnInteger = false;
            while (!userInputIsAnInteger || recipe.amountOfIceCubes > inventory.iceCubes.Count)
            {
                Console.WriteLine("Please enter the number of ice cubes per cup.");
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out recipe.amountOfIceCubes);

            }
            return recipe.amountOfIceCubes;

        }

        public double SetPricePerCup(Day day)
        {
            bool userInputIsAnInteger = false;
            while (!userInputIsAnInteger || recipe.PricePerCup <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Forecast: {1} degrees and {0}", day.weather.condition, day.weather.temperature);
                Console.WriteLine("Please set the price per cup.");
                userInputIsAnInteger = Double.TryParse(Console.ReadLine(), out recipe.PricePerCup);

            }
            return recipe.PricePerCup;
        }

        public double SetPricePerCup(Recipe recipe, Day day)
        {
            bool userInputIsAnInteger = false;
            while (!userInputIsAnInteger || recipe.PricePerCup <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Forecast: {1} degrees and {0}", day.weather.condition, day.weather.temperature);
                Console.WriteLine("Please set the price per cup.");
                userInputIsAnInteger = Double.TryParse(Console.ReadLine(), out recipe.PricePerCup);

            }
            return recipe.PricePerCup;
        }

        public void FillPitcher(int purchases)
        {
            if (purchases > 0)
            {
                if (purchases % 4 == 0)
                {
                    inventory.lemons.RemoveRange(0, recipe.amountOfLemons);
                    inventory.sugarCubes.RemoveRange(0, recipe.amountOfSugarCubes);
                }
            }
        }

        public void SellLemonade(Day day)
        {
            double i = day.random.Next(day.demandModifier, 21);
            for (int j = 0; j < i; j++)
            {
                day.customers[j].willBuy = true;
                day.customers[j].maxWillingToPay += day.demandModifier / 2;

                if ((recipe.PricePerCup <= day.customers[j].maxWillingToPay)
                    && (day.customers[j].willBuy = true)
                                && (inventory.lemons.Count >= recipe.amountOfLemons)
                                && (inventory.sugarCubes.Count >= recipe.amountOfSugarCubes)
                                && (inventory.iceCubes.Count >= recipe.amountOfIceCubes)
                                        && (inventory.cups.Count > 0))
                {
                    inventory.cups.RemoveAt(0);
                    inventory.iceCubes.RemoveRange(0, recipe.amountOfIceCubes);
                    day.purchases++;
                    FillPitcher(day.purchases);
                    Console.WriteLine();
                    Console.WriteLine(day.customers[j].name + " purchased a lemonade!");
                }
            }
            if (day.purchases > 0 && day.purchases < 4)
            {
                inventory.lemons.RemoveRange(0, recipe.amountOfLemons);
                inventory.sugarCubes.RemoveRange(0, recipe.amountOfSugarCubes);
            }

        }
    }
}

