namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double acConsumption = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            FuelConsumption += acConsumption;
            base.Drive(distance);
            FuelConsumption -= acConsumption;
        }

        public void DriveEmpty(double distance) => base.Drive(distance);
    }
}
