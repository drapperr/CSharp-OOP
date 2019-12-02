using System;

namespace Tests
{
    using NUnit.Framework;
    using FightingArena;

    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldCreateAWarriorWithCorrectParameters()
        {
            string expectedName = "Gosho";
            int expectedDamage = 20;
            int expectedHp = 50;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);
            string warriorName = warrior.Name;
            int warriorDamage = warrior.Damage;
            int warriorHp = warrior.HP;

            Assert.AreEqual(expectedName, warriorName);
            Assert.AreEqual(expectedDamage, warriorDamage);
            Assert.AreEqual(expectedHp, warriorHp);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NamePropertyShouldThrowExceptionWithNullOrEmptyOrWhitespace(string value)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(value, 10, 15));
        }

        [Test]
        public void DamagePropertyShouldThrowExceptionWithZeroOrNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", 0, 15));
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", -10, 15));
        }

        [Test]
        public void HpPropertyShouldThrowExceptionWithNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", 10, -15));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfHpIsLessThanMinAttackHp()
        {
            Warrior warrior = new Warrior("Gosho", 5, 20);
            Warrior warrior2 = new Warrior("Pesho", 20, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));
            Assert.Throws<InvalidOperationException>(() => warrior2.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfHpIsLessThanAttackerDamage()
        {
            Warrior warrior = new Warrior("Gosho", 10, 40);
            Warrior warrior2 = new Warrior("Pesho", 41, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior2));
        }

        [Test]
        public void AttackWhenThisDamageIsMoreFromAttackerHp()
        {
            Warrior warrior = new Warrior("Gosho", 46, 50);
            Warrior warrior2 = new Warrior("Pesho", 20, 45);

            warrior.Attack(warrior2);

            Assert.AreEqual(30,warrior.HP);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void AttackWhenAttackerDamageIsMoreFromThisHp()
        {
            Warrior warrior = new Warrior("Gosho", 30, 50);
            Warrior warrior2 = new Warrior("Pesho", 20, 45);

            warrior.Attack(warrior2);

            Assert.AreEqual(30, warrior.HP);
            Assert.AreEqual(15, warrior2.HP);
        }
    }
}