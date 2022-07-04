using System;
using System.Collections.Generic;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Foods;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Mammals.Felines;
using WildFarm.Factories;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] animalInfo = cmd.
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = AnimalFactory.CreateAnimal(animalInfo);
                Food food = FoodFactory.CreateFood(foodInfo);
                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());
                TryToFeedTheAnimal(animal, food);
            }

            DisplayAllAnimals(animals);
        }

        public static void TryToFeedTheAnimal(Animal animal, Food food)
        {

            if (animal.GetType().Name == "Hen")
            {
                animal.Weight += food.Quantity * 0.35;
                animal.FoodEaten += food.Quantity;
            }

            else if (animal.GetType().Name == "Mouse" &&
                    (food.GetType().Name == "Fruit" || food.GetType().Name == "Vegetable"))
            {
                animal.Weight += food.Quantity * 0.10;
                animal.FoodEaten += food.Quantity;
            }

            else if (animal.GetType().Name == "Cat" &&
                    (food.GetType().Name == "Meat" || food.GetType().Name == "Vegetable"))
            {
                animal.Weight += food.Quantity * 0.30;
                animal.FoodEaten += food.Quantity;
            }


            else if (animal.GetType().Name == "Tiger" && food.GetType().Name == "Meat")
            {
                animal.Weight += food.Quantity * 1.00;
                animal.FoodEaten += food.Quantity;
            }

            else if (animal.GetType().Name == "Dog" && food.GetType().Name == "Meat")
            {
                animal.Weight += food.Quantity * 0.40;
                animal.FoodEaten += food.Quantity;
            }

            else if (animal.GetType().Name == "Owl" && food.GetType().Name == "Meat")
            {
                animal.Weight += food.Quantity * 0.25;
                animal.FoodEaten += food.Quantity;
            }

            else
            {
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        private void DisplayAllAnimals(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
