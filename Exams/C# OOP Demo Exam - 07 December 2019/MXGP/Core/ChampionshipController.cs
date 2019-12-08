using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            riderRepository = new RiderRepository();
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
        }
        public string CreateRider(string riderName)
        {
            if (riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            riderRepository.Add(new Rider(riderName));

            return $"Rider {riderName} is created.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Power")
            {
                motorcycleRepository.Add(new PowerMotorcycle(model, horsePower));
                return $"PowerMotorcycle {model} is created.";
            }
            else if (type == "Speed")
            {
                motorcycleRepository.Add(new SpeedMotorcycle(model, horsePower));
                return $"SpeedMotorcycle {model} is created.";
            }

            throw new ArgumentException("Invalid type");
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            raceRepository.Add(new Race(name, laps));
            return $"Race {name} is created.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            raceRepository.GetByName(raceName).AddRider(riderRepository.GetByName(riderName));

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            riderRepository.GetByName(riderName).AddMotorcycle(motorcycleRepository.GetByName(motorcycleModel));

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }


            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var riders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
