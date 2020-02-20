using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Wallet
    {
        private double money;

        // property - TBD
        public double Money
        {
            get
            {
                return money;
            }

            set
            {
                if (value <= 0)
                {
                    value = 0;

                }
                money = value;
            }
        }

        public Wallet()
        {
            money = 20.00;
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public void ReceiveMoneyFromCustomers(Player player, double purchases)
        {
            Console.WriteLine();
            double profit = (purchases * player.recipe.PricePerCup);
            Console.WriteLine("Purchases: {0} Profit: {1}", purchases, profit);
            player.wallet.Money += profit;
            Console.WriteLine();
        }
    }
}
