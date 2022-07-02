using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] firstInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] secondInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            try
            {
                foreach (string person in firstInput)
                {
                    string[] currPersonInfo = person
                        .Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string name = currPersonInfo[0];
                    decimal money = decimal.Parse(currPersonInfo[1]);
                    Person personToAdd = new Person(name, money);
                    people.Add(personToAdd);
                }

                foreach (string product in secondInput)
                {
                    string[] currPersonInfo = product
                        .Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string name = currPersonInfo[0];
                    decimal money = decimal.Parse(currPersonInfo[1]);
                    Product productToAdd = new Product(name, money);
                    products.Add(productToAdd);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string personName = cmdArgs[0];
                string productName = cmdArgs[1];
                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);
                person.TryToBuyProuct(person, product);
            }

            foreach (Person person in people)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }

                else
                {
                    Console.WriteLine(person);
                }
            }

        }
    }
}
