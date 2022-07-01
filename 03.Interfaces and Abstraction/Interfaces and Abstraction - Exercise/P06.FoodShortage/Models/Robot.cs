using FoodShortage.Models;
using FoodShortage.Contracts;

namespace BorderControl
{
    public class Robot : Habitator, IIdentifiable
    {
        public Robot(string model, string id) : base (model)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }

        public string MyProperty { get; set; }

        public string Id { get; set; }
    }
}
