namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double initialOxygen = 50;

        public Geodesist(string name)
            : base(name, initialOxygen) { }
    }
}
