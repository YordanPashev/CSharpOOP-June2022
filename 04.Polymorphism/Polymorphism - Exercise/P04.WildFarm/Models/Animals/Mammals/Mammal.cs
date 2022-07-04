namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; protected set; }

        public override string ToString()
            => $"{this.GetType().Name} [{this.Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
