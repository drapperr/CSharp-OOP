using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            Aquarium aquarium=new Aquarium("George",15);

            Assert.That(aquarium.Name,Is.EqualTo("George"));
            Assert.That(aquarium.Capacity,Is.EqualTo(15));
            Assert.That(aquarium.Count,Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowArgumentNullExceptionWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(value, 15));
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWithInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("George", -1));
        }

        [Test]
        public void CountShouldIncreaseWhenAddFish()
        {
            Aquarium aquarium = new Aquarium("George", 15);

            Assert.That(aquarium.Count, Is.EqualTo(0));

            aquarium.Add(new Fish("myFish"));

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfCapacityIsFull()
        {
            Aquarium aquarium = new Aquarium("George", 1);

            aquarium.Add(new Fish("myFish"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("test")));
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionIfAquariumNotContainsThisFish()
        {
            Aquarium aquarium = new Aquarium("George", 1);

            aquarium.Add(new Fish("myFish"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("test"));
        }

        [Test]
        public void RemoveMethodShouldRemoveCorrectly()
        {
            Aquarium aquarium = new Aquarium("George", 1);

            aquarium.Add(new Fish("myFish"));

            Assert.That(aquarium.Count,Is.EqualTo(1));

            aquarium.RemoveFish("myFish");

            Assert.That(aquarium.Count, Is.EqualTo(0));

        }

        [Test]
        public void SellMethodShouldThrowInvalidOperationExceptionIfAquariumNotContainsThisFish()
        {
            Aquarium aquarium = new Aquarium("George", 1);

            aquarium.Add(new Fish("myFish"));

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("test"));
        }

        [Test]
        public void SellMethodShouldReturnThisFishAndSetAvailablePropertyToFalse()
        {
            Aquarium aquarium = new Aquarium("George", 10);

            Fish myFish = new Fish("myFish");

            aquarium.Add(myFish);

            Fish result = aquarium.SellFish("myFish");

            Assert.That(result,Is.EqualTo(myFish));
            Assert.That(result.Available,Is.EqualTo(false));
        }

        [Test]
        public void ReportMethodShouldReturnCorrectlyMessage()
        {
            Aquarium aquarium = new Aquarium("George", 10);

            Fish myFish = new Fish("myFish");
            Fish myFish2 = new Fish("myFish2");
            aquarium.Add(myFish);
            aquarium.Add(myFish2);

            string expectedResult = "Fish available at George: myFish, myFish2";

            string actuallyResult = aquarium.Report();

            Assert.That(actuallyResult,Is.EqualTo(expectedResult));
        }
    }
}
