using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        public string condition;
        public int temperature;
        List<string> weatherConditions;

        public Weather(int temperature, string condition)
        {
            this.temperature = temperature;
            this.condition = condition;
        }

        public int SetTemperature()
        {
            Random random = new Random();
            int temperature = random.Next(40, 100);
            return temperature;
        }

        public string SetWeatherCondition()
        {
            Random random = new Random();
            int i = random.Next(0, 3);
            weatherConditions = new List<string>
            {
                "Sunny",
                "Cloudy",
                "Rainy",
            };
            condition = weatherConditions[i];
            return condition;

        }








    }
}
