using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50M;

        public Coffee(string name, double coffein)
            : base(name, coffeePrice, coffeeMilliliters)
        {
            this.Caffeine = coffein;
        }

        public double Caffeine { get; set; }
    }
}
