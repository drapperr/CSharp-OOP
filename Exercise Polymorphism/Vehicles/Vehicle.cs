using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity)
        {
            if (fuel > tankCapacity)
            {
                fuel = 0;
            }
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }
        public double Fuel { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public virtual void Drive(double distance)
        {
            if (Fuel - distance * FuelConsumption >= 0)
            {
                Fuel -= distance * FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (Fuel + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            Fuel += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:F2}";
        }
    }
}
