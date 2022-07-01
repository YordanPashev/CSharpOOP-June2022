using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public abstract class Habitator : IHabitator
    {
        protected Habitator(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
