namespace SpaceStation.Models.Mission
{

    using System.Linq;

    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System.Collections.Generic;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            Queue<string> items = new Queue<string>(planet.Items);
            ICollection<IAstronaut> deadAstronauts = new List<IAstronaut>();
            
            foreach (IAstronaut astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    string item = items.Dequeue();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }

                if (!astronaut.CanBreath)
                {
                    deadAstronauts.Add(astronaut);
                }
            }

            foreach (IAstronaut deadAstronaut in deadAstronauts)
            {
                astronauts.Remove(deadAstronaut);
            }
        }
    }
}
