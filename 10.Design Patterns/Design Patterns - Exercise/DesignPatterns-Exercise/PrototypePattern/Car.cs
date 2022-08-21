namespace PrototypePattern
{
    public class Car
    {
        public Car(string make, string model, int year,List<Tire> tires)
        {
            Make = make;
            Model = model;
            Year = year;
            Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public List<Tire> Tires { get; set; }

        public Car? Clone()
        {
            Car? car = new Car(this.Make, this.Model, this.Year, new List<Tire>());

            foreach (Tire tire in this.Tires)
            {
                if (tire != null)
                {
                    car.Tires.Add(new Tire(tire.Model));
                }
            }

            return car;
        }

        public override string ToString()
        {
            return $"Make: {this.Make} | Model: {this.Model} | {this.Year}" + Environment.NewLine +
                   $"{string.Join(Environment.NewLine, Tires.Select(t => $"{t.Model} -> {t.Condition}"))}";
        }
    }
}
