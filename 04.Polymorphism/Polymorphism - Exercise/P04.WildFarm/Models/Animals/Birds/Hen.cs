﻿namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize) { }

        public override string ProduceSound()
            => "Cluck";
    }
}
