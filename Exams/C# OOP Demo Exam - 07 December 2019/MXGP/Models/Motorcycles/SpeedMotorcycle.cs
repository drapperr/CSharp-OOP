using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, 125.0)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}
