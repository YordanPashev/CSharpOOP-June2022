using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Beast!")
            {
                string animalType = cmd;
                string[] token = Console.ReadLine()
                    .Split();

                string name = token[0];
                int age = int.Parse(token[1]);
                string gender = token[2];

                if (string.IsNullOrEmpty(name) ||
                    age < 0 ||
                    string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                AddAnimalToTheList(animals, animalType, name, age, gender);
            }

            DisplayAllAnimalsData(animals);
        }

        private static void DisplayAllAnimalsData(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }

        private static void AddAnimalToTheList(List<Animal> animals, string animalType, string name, int age, string gender)
        {
            if (animalType == "Dog")
            {
                Dog dog = new Dog(name, age, gender);
                animals.Add(dog);
            }

            else if (animalType == "Frog")
            {
                Frog frog = new Frog(name, age, gender);
                animals.Add(frog);
            }

            else if (animalType == "Cat")
            {
                Cat cat = new Cat(name, age, gender);
                animals.Add(cat);
            }

            else if (animalType == "Kitten")
            {
                Kitten kitty = new Kitten(name, age);
                animals.Add(kitty);
            }

            else if (animalType == "Tomcat")
            {
                Tomcat tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
            }
        }
    }
}

