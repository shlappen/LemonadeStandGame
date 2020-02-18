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

        public Day(string name)
        {
            weather = null;
            this.name = name;
            customers = new List<Customer>
            {
                new Customer ("Leonardo Panini"),
                new Customer ("Ivan the Amicable"),
                new Customer ("Boniface"),
                new Customer ("Old Thirsty Jackson"),
                new Customer ("Little Big River Zielinski"),
                new Customer ("Sir Paul"),
                new Customer ("Sebastian Stevenson-Johnson"),
                new Customer ("Billy the Adult"),
                new Customer ("Sally Fingerburger"),
                new Customer ("Babwa Wawa"),
                new Customer ("Greasy Todd Peterson"),
                new Customer ("Ice Cube"),
                new Customer ("Trapper Keeper Williams"),
                new Customer ("Basketball Jones"),
                new Customer ("Salt 'N' Pepa"),
                new Customer ("Dr. Orange Julius"),
                new Customer ("Stephanie McWoman"),
                new Customer ("Jessica Plainface"),
                new Customer ("Mia Wallace"),
                new Customer ("Chong")
            };
        }

        public void GetWillBuy()
        {
        }
        
    }
}
