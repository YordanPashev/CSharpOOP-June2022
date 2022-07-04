namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
           : base(name, weight, livingRegion) { }

        public override string ProduceSound()
            => "Woof!";
    }
}
