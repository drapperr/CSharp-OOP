using System;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Motorcycle != null;

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            this.Motorcycle = motorcycle ?? throw new ArgumentNullException(nameof(motorcycle),"Motorcycle cannot be null.");
        }
    }
}
