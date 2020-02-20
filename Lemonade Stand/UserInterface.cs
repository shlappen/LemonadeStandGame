using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {



        public static string SetPlayerName()
        {
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            return name;
        }

        public static void DisplayRules()
        {
            Console.WriteLine("Your goal is to make as much money as you can in 7 days by selling lemonade at your lemonade stand. " +
                "Buy cups, lemons, sugar, and ice cubes, then set your price based on the weather and conditions. " +
                "Try changing up the price based on the weather conditions. " +
                "With the right price and a little bit of luck, your lemonade stand can become a multi-national conglomerate. ");        }

        public static void DisplayStoreOptions()
        {
            Console.WriteLine("1) Buy lemons. 50 cents per unit.");
            Console.WriteLine("2) Buy sugar cubes. 10 cents per unit.");
            Console.WriteLine("3) Buy ice cubes.  1 cent per unit.");
            Console.WriteLine("4) Buy cups.  25 cents per unit.");
            Console.WriteLine("Press 5 to leave store.");
        }
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static void NotEnoughInventoryCheck(Player player)
        {
            if (player.inventory.lemons.Count < player.recipe.amountOfLemons
                || player.inventory.sugarCubes.Count < player.recipe.amountOfSugarCubes
                || player.inventory.iceCubes.Count < player.recipe.amountOfSugarCubes)
            {
                Console.WriteLine("Sold out of inventory!");
            }
        }




    }
}
