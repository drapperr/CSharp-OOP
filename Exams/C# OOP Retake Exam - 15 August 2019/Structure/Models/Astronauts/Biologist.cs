namespace SpaceStation.Models.Astronauts
{
    using System;

    public class Biologist : Astronaut
    {
        private const int InitialOxygenPoints = 70;

        public Biologist(string name) 
            : base(name, InitialOxygenPoints)
        {
        }

        public override void Breath()
        {
            this.Oxygen = Math.Max(this.Oxygen - 5, 0);
        }
    }
}
