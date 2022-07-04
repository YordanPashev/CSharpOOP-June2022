namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
