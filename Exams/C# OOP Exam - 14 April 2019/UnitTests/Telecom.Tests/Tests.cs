using System;

namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Make_IsNullOrEmpty()
        {
            Phone phone;
            var ex = Assert.Throws<ArgumentException>(() => phone = new Phone(null, "myModel"));
            Assert.That(ex.Message, Is.EqualTo("Invalid Make!"));
        }
        public void Make_IsValid()
        {
            Phone phone = new Phone("myMake", "myModel");
            Assert.AreEqual("myMake",phone.Make);
        }

        [Test]
        public void Model_IsNullOrEmpty()
        {
            Phone phone;
            var ex = Assert.Throws<ArgumentException>(() => phone = new Phone("myMake", null));
            Assert.That(ex.Message, Is.EqualTo("Invalid Model!"));
        }
        public void Model_IsValid()
        {
            Phone phone = new Phone("myMake", "myModel");
            Assert.AreEqual("myModel", phone.Model);
        }

        [Test]
        public void PhoneBookCount_Test()
        {
            Phone phone = new Phone("Nokia", "3310");
            Assert.AreEqual(0, phone.Count);

            phone.AddContact("ivo", "1111");
            Assert.AreEqual(1, phone.Count);

            phone.AddContact("goo", "2222");
            Assert.AreEqual(2, phone.Count);
        }

        [Test]
        public void AddContact_Test()
        {
            Phone phone = new Phone("Nokia", "3310");
            phone.AddContact("ivo", "1111");
            var ex = Assert.Throws<InvalidOperationException>(() => phone.AddContact("ivo", "1111"));
            Assert.AreEqual("Person already exists!",ex.Message);
        }

        [Test]
        public void CallContact_Test()
        {
            Phone phone = new Phone("Nokia", "3310");
            var ex = Assert.Throws<InvalidOperationException>(() => phone.Call("stoyan"));
            Assert.AreEqual("Person doesn't exists!", ex.Message);
            phone.AddContact("stoyan", "1234");
            string result = phone.Call("stoyan");
            Assert.AreEqual("Calling stoyan - 1234...",result);
        }
    }
}