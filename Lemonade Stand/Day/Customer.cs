using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        public string name;
        public bool willBuy;
        public int maxWillingToPay;

        public Customer(string name)
        {
            this.name = name;
            willBuy = false;
            maxWillingToPay = 1;

        }


    }
}
