using System;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string pizzaInfo = Console.ReadLine();
                string nameOfthePizza = string.Empty;

                if (!pizzaInfo.Contains(" "))
                {
                    nameOfthePizza = string.Empty;
                }

                else
                {
                    nameOfthePizza = pizzaInfo.Split()[1];
                }

                string[] flourInfo = Console.ReadLine()
                           .Split()
                           .ToArray();
                string doughType = flourInfo[1];
                string backingTechnique = flourInfo[2];
                double florWeighInGrams = double.Parse(flourInfo[3]);
                Dough dough = new Dough(doughType, backingTechnique, florWeighInGrams);

                Pizza pizza = new Pizza(nameOfthePizza, dough);

                string cmd;
                while ((cmd = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = cmd
                        .Split()
                        .ToArray();

                    string toppingType = toppingInfo[1];
                    double toppingWeighInGrams = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeighInGrams);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

        }
    }
}
