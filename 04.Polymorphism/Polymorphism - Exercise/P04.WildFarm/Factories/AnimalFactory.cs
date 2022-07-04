using System;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            Animal animal = null;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal=  new Owl(name, weight, wingSize);
            }

            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }

            else if (type == "Mouse")
            {
                string livingRegion = animalInfo[3];
                animal = new Mouse(name, weight, livingRegion);
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
                animal = new Cat(name, weight, livingRegion, breed);
            }

            else if (type == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }

    }
}
