using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double carFuel = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carFuelCapacity = double.Parse(carInfo[3]);
            var car = new Car(carFuel,carFuelConsumption,carFuelCapacity);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double truckFuel = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckFuelCapacity = double.Parse(truckInfo[3]);
            var truck = new Truck(truckFuel, truckFuelConsumption, truckFuelCapacity);

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double busFuel = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busFuelCapacity = double.Parse(busInfo[3]);
            var bus = new Bus(busFuel, busFuelConsumption, busFuelCapacity);

            Dictionary<string,Vehicle> vehicles=new Dictionary<string, Vehicle>();
            vehicles.Add("Car",car);
            vehicles.Add("Truck",truck);
            vehicles.Add("Bus",bus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string type = input[1];
                double num = double.Parse(input[2]);

                try
                {
                    switch (command)
                    {
                        case "Drive":
                            vehicles[type].Drive(num);
                            break;
                        case "Refuel":
                            vehicles[type].Refuel(num);
                            break;
                        case "DriveEmpty":
                            bus.DriveEmpty(num);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } 
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Value);
            }
        }
    }
}
