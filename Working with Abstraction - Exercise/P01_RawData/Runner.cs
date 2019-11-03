using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public static class Runner
    {
        public static void Run()
        {
            List<Car> cars = new List<Car>();

            AddCars(cars);
            ShowTargetCars(cars);
        }

        private static void ShowTargetCars(List<Car> cars)
        {
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static void AddCars(List<Car> cars)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];

                for (int j = 5; j <= 12; j += 2)
                {
                    double pressure = double.Parse(parameters[j]);
                    int age = int.Parse(parameters[j + 1]);

                    tires[(j - 5) / 2] = new Tire(pressure, age);
                }
                cars.Add(new Car(model, engine, cargo, tires));
            }
        }
    }
}
