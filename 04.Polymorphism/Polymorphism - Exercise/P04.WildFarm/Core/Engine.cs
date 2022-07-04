using System;
using System.Collections.Generic;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Foods;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Mammals.Felines;

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

                Animal animal = CreateAnimal(animalInfo);
                Food food = CreateFood(foodInfo);
                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());
                TryToFeedTheAnimal(animal, food);
            }

            DisplayAllAnimals(animals);
        }

        private Animal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);
                return new Owl (name, weight, wingSize); 
            }

            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                return new Hen(name, weight, wingSize);
            }

            else if (type == "Mouse")
            {
                string livingRegion = animalInfo[3];
                return new Mouse(name, weight, livingRegion);
            }

            else if (type == "Dog")
            {
                string livingRegion = animalInfo[3];
                return new Dog(name, weight, livingRegion);
            }

            else if (type == "Cat")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                return new Cat(name, weight, livingRegion, breed);
            }

            else if (type == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                return new Tiger(name, weight, livingRegion, breed);
            }

            return null;
        }


        private Food CreateFood(string[] foodInfo)
        {
            string type = foodInfo[0];
            int qunatity = int.Parse(foodInfo[1]);

            if (type == "Vegetable")
            {
                return new Vegetable(qunatity);
            }

            else if (type == "Fruit")
            {
                return new Fruit(qunatity);
            }

            else if (type == "Meat")
            {
                return new Meat(qunatity);
            }

            else if (type == "Seeds")
            {
                return new Seeds(qunatity);
            }

            return null;
        }

        private void TryToFeedTheAnimal(Animal animal, Food food)
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
