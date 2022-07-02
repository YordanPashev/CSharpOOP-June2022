using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            private set
            {
                string typeName = value.ToLower();
                if (typeName != "meat" && typeName != "veggies" &&
                    typeName != "cheese" && typeName != "sauce")
                {
                    string topping = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    string topping = this.toppingType[0].ToString().ToUpper() + this.toppingType.Substring(1);
                    throw new ArgumentException($"{topping} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double GetCalaries()
            => (2 * weight) * ToppingTypeModifier(toppingType.ToLower());

        private double ToppingTypeModifier(string type)
        {
            switch (type)
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
                default:
                    return 0;
            }
        }
    }
}

