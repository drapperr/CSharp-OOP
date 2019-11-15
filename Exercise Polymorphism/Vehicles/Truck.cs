using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        private const double acConsumption = 1.6;

        public Truck(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += acConsumption;
        }

        public override void Refuel(double liters)
        {
            if (Fuel + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
