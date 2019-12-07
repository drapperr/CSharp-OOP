using System;
using System.Collections.Generic;

namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        [Test]
        public void ParkingPropertyShouldReturnEmptyParking()
        {
            SoftPark softPark = new SoftPark();

            var testParking = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEqual(testParking, softPark.Parking);
        }

        [Test]
        public void ParkCarShouldShoulAddCar()
        {
            var car = new Car("BMW", "2215");

            var parking = new SoftPark();

            string actualResult = parking.ParkCar("A1", car);
            string expectedResult = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(car, parking.Parking["A1"]);
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void ParkCarShouldThrowExceptionWithInvalidCarSpot()
        {
            var car = new Car("BMW", "2215");

            var parking = new SoftPark();

            Assert.Throws<ArgumentException>(()
                => parking.ParkCar("z11", car));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfCarSpotIsNotEmpty()
        {
            var car = new Car("BMW", "2215");
            var car2 = new Car("Audi", "5115");

            var parking = new SoftPark();

            parking.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(()
                => parking.ParkCar("A1", car2));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfRegistrationNumberIsAlreadyExist()
        {
            var car = new Car("BMW", "2215");
            var car2 = new Car("Audi", "2215");

            var parking = new SoftPark();

            parking.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(()
                => parking.ParkCar("A2", car2));
        }

        [Test]
        public void RemoveCarMethodShouldRemoveCar()
        {
            var car = new Car("BMW", "2215");

            var parking = new SoftPark();
            parking.ParkCar("B2", car);

            string actualResult = parking.RemoveCar("B2", car);
            string expectedResult = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(null, parking.Parking["B2"]);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveCarShouldThrowExceptionWithInvalidCarSpot()
        {
            var car = new Car("BMW", "2215");

            var parking = new SoftPark();

            parking.ParkCar("C3", car);

            Assert.Throws<ArgumentException>(() =>
                parking.RemoveCar("Z1", car));
        }

        [Test]
        public void RemoveCarShouldThrowExceptionWithInvalidCar()
        {
            var car = new Car("BMW", "4533");
            var car2 = new Car("Audi", "2215");

            var parking = new SoftPark();

            parking.ParkCar("C3", car);

            Assert.Throws<ArgumentException>(() =>
                parking.RemoveCar("C3", car2));
        }
    }
}