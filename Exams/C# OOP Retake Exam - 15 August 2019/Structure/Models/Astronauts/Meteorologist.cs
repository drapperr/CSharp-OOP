namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const int InitialOxygenPoints = 90;

        public Meteorologist(string name)
            : base(name, InitialOxygenPoints)
        {
        }
    }
}
