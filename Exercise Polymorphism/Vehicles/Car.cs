namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double acConsumption = 0.9;

        public Car(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {
            fuelConsumption += acConsumption;
        }
    }
}
