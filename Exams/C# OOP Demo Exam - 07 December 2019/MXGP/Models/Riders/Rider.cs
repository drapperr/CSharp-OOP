namespace MXGP.Models.Riders
{
    using System;
    using MXGP.Models.Motorcycles.Contracts;
    using Contracts;
    using MXGP.Utilities.Messages;

    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle), ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;
        }
    }
}
