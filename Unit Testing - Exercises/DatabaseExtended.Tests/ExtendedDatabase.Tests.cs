using System;

namespace Tests
{
    using NUnit.Framework;
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddMethodThrowExceptionWhenTryToAddPersonWhenDatabaseIsFull()
        {
            var persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i]=new Person(i,$"name{i}");
            }

            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(123,"Pesho")));

        }

        [Test]
        public void AddMethodThrowExceptionWhenTryToAddPersonWithExistingName()
        {
            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Person personWithsSameName = new Person(0000, "Gosho");
            Assert.Throws<InvalidOperationException>(() => database.Add(personWithsSameName));
        }

        [Test]
        public void AddMethodThrowExceptionWhenTryToAddPersonWithExistingId()
        {
            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Person personWithsSameId = new Person(1234, "Pesho");
            Assert.Throws<InvalidOperationException>(() => database.Add(personWithsSameId));
        }

        [Test]
        public void AddMethodShouldAddCorrectly()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person=new Person(1234,"Gosho");
            database.Add(person);

            Assert.AreEqual(1,database.Count);
        }

        [Test]
        public void RemoveMethodThrowExceptionWhenDatabaseIsEmpty()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveLastPerson()
        {
            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);
            database.Remove();

            Assert.AreEqual(0,database.Count);
        }

        [Test]
        public void ConstructorThrowExceptionWhenTryToAddMorePersons()
        {
            var persons = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(i, $"name{i}");
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));

        }

        [Test]
        public void ConstructorShouldAddCorrect()
        {
            Person person = new Person(1234, "Gosho");

            ExtendedDatabase database = new ExtendedDatabase(person);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfUsernameIsNotContains()
        {

            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(()=>database.FindByUsername("NoName"));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfUsernameIsNull()
        {

            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameMethodShouldReturnCorrectUser()
        {

            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Person expectedPerson =database.FindByUsername("Gosho");

            Assert.AreEqual(person,expectedPerson);
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdIsNotContains()
        {

            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => database.FindById(3));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdIsNegative()
        {

            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-10));

        }

        [Test]
        public void FindByIdMethodShouldReturnCorrectUser()
        {

            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Person expectedPerson = database.FindById(1234);

            Assert.AreEqual(person, expectedPerson);
        }

        [Test]
        public void CountMethodShouldReturnCountOfElements()
        {
            Person person = new Person(1234, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(person);

            Assert.AreEqual(1,database.Count);
        }
    }
}