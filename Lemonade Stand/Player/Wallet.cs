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
        //double Money
        //{
        //    get
        //    {
        //        return money;
        //    }

        //    set
        //    {
        //        if (value <= 0)
        //        {
        //            value = 0;

        //        }
        //        money = value;
        //    }
        //}

        public Wallet()
        {
            money = 20.00;
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            if(money >=  transactionAmount)
            {
                money -= transactionAmount;
            }
            else
            {
                Console.WriteLine("Not enough money to perform transaction!");
            }
            
        }

        public void ReceiveMoneyFromCustomers(Player player, Day day)
        {
            Console.WriteLine();
            double profit = (day.purchases * player.recipe.PricePerCup);
            Console.WriteLine("Purchases: {0} Profit: {1}", day.purchases, profit);
            money += profit;
            Console.WriteLine();
        }

        public void DisplayMoney()
        {
            Console.WriteLine("Your money: ${0}", money);
        }
    }
}
