using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IMotorcycle> motorcyclerRepository;
        private IRepository<IRider> riderRepository;
        private IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.motorcyclerRepository = new MotorcycleRepository();
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateRider(string riderName)
        {
            IRider rider = this.riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = this.motorcyclerRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type + "Motorcycle" == nameof(SpeedMotorcycle))
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            if (type + "Motorcycle" == nameof(PowerMotorcycle))
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motorcyclerRepository.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riderRepository.GetByName(riderName);
            IMotorcycle motorcycle = this.motorcyclerRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            IRider rider = this.riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,raceName,3));
            }

            IList<IRider> bestRiders =race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            this.raceRepository.Remove(race);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, bestRiders[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, bestRiders[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, bestRiders[2].Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}
