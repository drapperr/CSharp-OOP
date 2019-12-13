using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [Test]
        public void ConstructorShouldCreateEmptyDictionary()
        {
            RaceEntry raceEntry = new RaceEntry();
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }

        [Test]
        public void CounterShouldIncrease()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("trt", new UnitMotorcycle("phs", 12, 41)));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddRiderMethodShouldThrowInvalidOperationExceptionWithInvalidRider()
        {
            RaceEntry raceEntry = new RaceEntry();
            var ex = Assert.Throws<InvalidOperationException>((() => raceEntry.AddRider(null)));
            Assert.That(ex.Message,Is.EqualTo("Rider cannot be null."));
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddRiderMethodShouldThrowInvalidOperationExceptionIfRiderNameIsAlwaysExist()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("trt", new UnitMotorcycle("phs", 12, 41)));
            var ex = Assert.Throws<InvalidOperationException>((() => raceEntry.AddRider(new UnitRider("trt", new UnitMotorcycle("drt", 32, 19)))));
            Assert.That(ex.Message, Is.EqualTo("Rider trt is already added."));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddRiderMethodShouldAddRiderAndReturnCorrectMessage()
        {
            RaceEntry raceEntry = new RaceEntry();
            var result = raceEntry.AddRider(new UnitRider("trt", new UnitMotorcycle("phs", 12, 41)));

            string expectedResult = "Rider trt added in race.";

            Assert.That(raceEntry.Counter, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowInvalidOperationExceptionIfRidersCountIsLessThanMinParticipants()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("trt", new UnitMotorcycle("phs", 12, 41)));
            var ex = Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
            Assert.That(ex.Message, Is.EqualTo("The race cannot start with less than 2 participants."));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectResult()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("trt", new UnitMotorcycle("phs", 12, 41)));
            raceEntry.AddRider(new UnitRider("otp", new UnitMotorcycle("srt", 20, 4)));

            var expectedResult = 16;
            var result = raceEntry.CalculateAverageHorsePower();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}