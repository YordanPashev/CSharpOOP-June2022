namespace PrototypePattern
{
    public class Tire
    {
        public Tire(string model)
        {
            Model = model;
            Condition = "Good";
        }

        public string Model { get; set; }

        public string Condition { get; set; }
    }
}