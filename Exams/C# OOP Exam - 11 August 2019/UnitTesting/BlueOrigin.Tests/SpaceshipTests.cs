namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowArgumentNullExceptionWithNullOrEmptyForName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(value, 100));
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Estador", -1));
        }

        [Test]
        public void ConstructorShouldSetCorrectlyValues()
        {
            Spaceship spaceship = new Spaceship("Test", 50);

            Assert.That(spaceship.Name,Is.EqualTo("Test"));
            Assert.That(spaceship.Capacity,Is.EqualTo(50));
            Assert.That(spaceship.Count,Is.EqualTo(0));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfCapacityIsFull()
        {
            Spaceship spaceship = new Spaceship("Test", 1);
            spaceship.Add(new Astronaut("Ivan",40));

            Assert.Throws<InvalidOperationException>((() => spaceship.Add(new Astronaut("Dimo", 50))));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfSpaceshipContainsAstronautWithThisName()
        {
            Spaceship spaceship = new Spaceship("Test", 2);
            spaceship.Add(new Astronaut("Ivan", 40));

            Assert.Throws<InvalidOperationException>((() => spaceship.Add(new Astronaut("Ivan", 50))));
        }

        [Test]
        public void AddMethodShouldShouldAddCorrectlyThisAstronaut()
        {
            Spaceship spaceship = new Spaceship("Test", 2);

            Assert.That(spaceship.Count,Is.EqualTo(0));

            spaceship.Add(new Astronaut("Ivan", 40));

            Assert.That(spaceship.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveMethodShouldReturnFalseIfAstronautIsNotContains()
        {
            Spaceship spaceship = new Spaceship("Test", 2);

            spaceship.Add(new Astronaut("Ivan", 40));

            Assert.That(spaceship.Remove("Dragan"),Is.EqualTo(false));
        }

        [Test]
        public void RemoveMethodShouldReturnTrueIfAstronautIsContains()
        {
            Spaceship spaceship = new Spaceship("Test", 2);

            spaceship.Add(new Astronaut("Ivan", 40));

            Assert.That(spaceship.Remove("Ivan"), Is.EqualTo(true));
        }
    }
}