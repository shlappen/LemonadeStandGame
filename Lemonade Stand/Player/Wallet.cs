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
    }
}
