using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public class Rebel : Habitator, IBuyer
    {
        public Rebel(string name,int age, string group) : base(name)
        {
            Age = age;
            Group = group;
        }

        public int Age { get; set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
