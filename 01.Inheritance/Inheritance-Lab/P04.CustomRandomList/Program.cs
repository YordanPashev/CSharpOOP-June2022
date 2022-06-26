using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Penko");
            list.Add("Vanko");

            
            Console.WriteLine(list.RandomString() + " has been removed from the list.");

            Console.WriteLine();
            Console.WriteLine("List of people:");
            foreach (var person in list)
            {
                Console.WriteLine(person);
            }
        }
    }
}
