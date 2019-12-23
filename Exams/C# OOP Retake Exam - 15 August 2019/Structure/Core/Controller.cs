namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using Models.Mission;
    using Models.Planets;
    using Repositories;
    using SpaceStation.Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planetRepository;
        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.planetRepository=new PlanetRepository();
            this.astronautRepository=new AstronautRepository();
            this.mission=new Mission();
            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidRetiredAstronaut);
            }

            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            if (suitableAstronauts.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository.FindByName(planetName);

            mission.Explore(planet, suitableAstronauts);
            this.exploredPlanetsCount++;

            int deadAstronauts = suitableAstronauts.Count(a => !a.CanBreath);

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");

                if (astronaut.Bag.Items.Count==0)
                {
                    sb.AppendLine("none");
                }
                else
                {
                    sb.AppendLine(string.Join(", ",astronaut.Bag.Items));
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
