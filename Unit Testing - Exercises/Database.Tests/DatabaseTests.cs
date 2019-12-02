using System;

namespace Tests
{
    using NUnit.Framework;
    using Database;

    public class DatabaseTests
    {
        [Test]
        public void TestConstructorIsCorrectly()
        {
            var database = new Database(new int[16]);
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void ConstructorShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[17]));
        }

        [Test]
        public void AddMethodShouldThrowException()
        {
            var database = new Database(new int[16]);
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void AddMethodShouldAddCorrectly()
        {
            var database = new Database(new int[10]);
            database.Add(1);
            Assert.AreEqual(11, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowException()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveLastItem()
        {
            var database = new Database(new int[3] { 1, 2, 3 });
            database.Remove();
            CollectionAssert.AreEqual(new int[2] { 1, 2 }, database.Fetch());
        }

        [Test]
        public void FetchMethodShouldReturnArray()
        {
            var database = new Database(new int[3] { 1, 2, 3 });
            CollectionAssert.AreEqual(new int[3] { 1, 2, 3 }, database.Fetch());
        }

    }
}