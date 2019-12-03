using System;

namespace Telecom.Tests
{
    using NUnit.Framework;
    using Telecom;

    public class Tests
    {
        [Test]
        public void ConstructorShouldSetCorrectValues()
        {
            Phone phone = new Phone("myMake", "myModel");

            Assert.AreEqual("myMake", phone.Make);
            Assert.AreEqual("myModel", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
                new Phone(make, "myModel"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenMadeIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() 
                => new Phone("myMake", model));
        }

        [Test]
        public void AddContactMethodShouldSetACorrectContacts()
        {
            Phone phone = new Phone("Nokia", "3310");
            Assert.AreEqual(0, phone.Count);

            phone.AddContact("ivo", "1111");
            Assert.AreEqual(1, phone.Count);

            phone.AddContact("goo", "2222");
            Assert.AreEqual(2, phone.Count);
        }

        [Test]
        public void AddContactMethodShouldThrowExceptionIfContactNameIsExists()
        {
            Phone phone = new Phone("Nokia", "3310");
            phone.AddContact("ivo", "1111");
            Assert.Throws<InvalidOperationException>(() 
                => phone.AddContact("ivo", "5423"));
        }

        [Test] 
        public void CallMethodShouldThrowExceptionIfContactNameIsNotExists()
        {
            Phone phone = new Phone("Nokia", "3310");
            phone.AddContact("ivo", "1111");
            Assert.Throws<InvalidOperationException>(()
                => phone.Call("stoyan"));
        }

        [Test]
        public void CallMethodShouldCallCorrectly()
        {
            Phone phone = new Phone("Nokia", "3310");
            phone.AddContact("stoyan", "1234");
            string result = phone.Call("stoyan");
            Assert.AreEqual("Calling stoyan - 1234...", result);
        }
    }
}