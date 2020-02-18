using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
            else
            {
                Console.WriteLine("Not enough money to perform transaction!");
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar cubes");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
            else
            {
                Console.WriteLine("Not enough money to perform transaction!");
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
            else
            {
                Console.WriteLine("Not enough money to perform transaction!");
            }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }
            else
            {
                Console.WriteLine("Not enough money to perform transaction!");

            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            Console.WriteLine("Transaction amount: " + "$" + transactionAmount);
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            Console.WriteLine("Press Y to proceed, N to cancel.");
            bool isValid = false;
            string input = Console.ReadLine().ToLower();
                switch (input)
            {
                case "y":
                case "yes":
                    isValid = true;
                    break;
                case "n":
                case "no":
                    transactionAmount = 0;
                    isValid = true;
                    break;
                default: Console.WriteLine("Press Y to proceed, N to cancel.");
                    break;

            }while (isValid == false) ;

            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
