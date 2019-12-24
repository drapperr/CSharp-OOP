namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const int InitialOxygenPoints = 50;

        public Geodesist(string name)
            : base(name, InitialOxygenPoints)
        {
        }
    }
}
