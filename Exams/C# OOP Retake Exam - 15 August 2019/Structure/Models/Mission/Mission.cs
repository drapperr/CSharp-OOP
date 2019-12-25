namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using Astronauts.Contracts;
    using Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                string item = planet.Items.FirstOrDefault();

                while (item != null && astronaut.CanBreath)
                {
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    item = planet.Items.FirstOrDefault();
                }
            }
        }
    }
}
