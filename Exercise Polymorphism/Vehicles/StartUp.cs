using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine()
                .Split();
            double carFuel = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carFuelCapacity = double.Parse(carInfo[3]);
            var car = new Car(carFuel,carFuelConsumption,carFuelCapacity);

            string[] truckInfo = Console.ReadLine()
                .Split();
            double truckFuel = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckFuelCapacity = double.Parse(truckInfo[3]);
            var truck = new Truck(truckFuel, truckFuelConsumption, truckFuelCapacity);

            string[] busInfo = Console.ReadLine()
                .Split();
            double busFuel = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busFuelCapacity = double.Parse(busInfo[3]);
            var bus = new Bus(busFuel, busFuelConsumption, busFuelCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string command = input[0];
                string type = input[1];
                double value = double.Parse(input[2]);

                try
                {
                    if (command=="Drive")
                    {
                        if (type=="Car")
                        {
                            car.Drive(value);
                        }
                        else if (type=="Truck")
                        {
                            truck.Drive(value);
                        }
                        else if(type=="Bus")
                        {
                            bus.Drive(value);
                        }
                    }
                    else if (command=="Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (command== "DriveEmpty")
                    {
                        if (type == "Bus")
                        {
                            bus.DriveEmpty(value);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } 
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
