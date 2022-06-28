using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get => bagOfProducts.AsReadOnly();
        }

        public override string ToString()
            => $"{this.Name} - {string.Join(", ", bagOfProducts)}";

        public void TryToBuyProuct(Person person, Product product)
        {
            if (person.Money < product.Cost)
            {
                Console.WriteLine($"{ person.Name } can't afford {product.Name}");
            }

            else
            {
                person.bagOfProducts.Add(product);
                person.Money -= product.Cost;
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            
        }
    }
}
