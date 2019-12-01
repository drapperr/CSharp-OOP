using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {

        [Test]
        public void TestConstructor()
        {
            string make = "Audi";
            string model = "A4";
            double fuelConsumption = 4.2;
            double fuelCapacity = 80;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(null, "A4", 4.2, 80)]
        [TestCase("Audi", null, 4.2, 80)]
        [TestCase("Audi", "A4", 0, 80)]
        [TestCase("Audi", "A4", -10, 80)]
        [TestCase("Audi", "A4", 4.2, 0)]
        [TestCase("Audi", "A4", 4.2, -20)]
        public void TestAllMethodsForExceptions(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void TestFuelRefuelWithNegativeOrZero(double fuel)
        {
            string make = "Audi";
            string model = "A4";
            double fuelConsumption = 4.2;
            double fuelCapacity = 80;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void TestFuelRefuelNormally()
        {
            string make = "Audi";
            string model = "A4";
            double fuelConsumption = 4.2;
            double fuelCapacity = 80;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(50);

            Assert.AreEqual(50,car.FuelAmount);
        }

        [Test]
        public void TestFuelRefuelOverflow()
        {
            string make = "Audi";
            string model = "A4";
            double fuelConsumption = 4.2;
            double fuelCapacity = 80;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(100);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveNormally()
        {

            string make = "Audi";
            string model = "A4";
            double fuelConsumption = 4.2;
            double fuelCapacity = 80;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(100);

            Assert.AreEqual(15.8, car.FuelAmount);
        }

        [Test]
        public void DriveMoreThenFuelCapacity()
        {

            string make = "Audi";
            string model = "A4";
            double fuelConsumption = 4.2;
            double fuelCapacity = 80;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(()=> car.Drive(1000));
        }
    }
}