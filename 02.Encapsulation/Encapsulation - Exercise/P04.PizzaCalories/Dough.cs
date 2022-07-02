using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                string flourName = value.ToLower();
                if (flourName != "white" && flourName != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                string technique = value.ToLower();
                if (technique != "crispy" && technique != "chewy" && technique != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight 
        {
            get => weight;
            private set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double GetCalaries()
            => (2 * weight) * FlourModifier(flourType.ToLower()) * BakinTechniqueModifier(bakingTechnique.ToLower());

        private double FlourModifier(string flour)
        {
            switch (flour)
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1.0;
                default:
                    return 0;
            }
        }

        private double BakinTechniqueModifier(string technique) 
        {
            switch (technique)
            {
                case "crispy":
                    return 0.9;
                case "chewy":
                    return 1.1;
                case "homemade":
                    return 1.0;
                default:
                    return 0;
            }
        }
    }
}
