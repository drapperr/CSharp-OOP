using System;
using System.Collections.Generic;

namespace Tests
{
    using NUnit.Framework;
    using FightingArena;

    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldCreateNewList()
        {
            Arena arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfTryToAddWarriorWithSameName()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Gosho", 20, 50);
            Warrior warrior2 = new Warrior("Gosho", 30, 60);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
        }

        [Test]
        public void EnrollMethodShouldAddTwoWarriors()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Gosho", 20, 50);
            Warrior warrior2 = new Warrior("Pesho", 30, 60);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            List<Warrior> expectedWarriors = new List<Warrior>();
            expectedWarriors.Add(warrior1);
            expectedWarriors.Add(warrior2);

            Assert.AreEqual(2, arena.Count);
            CollectionAssert.AreEqual(expectedWarriors, arena.Warriors);
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfAttackerIsNotContainsInArena()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Gosho", 20, 50);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Pesho", "Gosho"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfDefenderIsNotContainsInArena()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Gosho", 20, 50);
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Gosho", "Pesho"));
        }


        [TestCase(5, 20, 20, 50)]
        [TestCase(10, 40, 41, 50)]

        public void AttackMethodShouldThrowExceptionIfHpIsLessThanMinAttackHp(
            int attackerDamage, int attackerHp, int defenderDamage, int defenderHp)
        {
            Warrior warrior = new Warrior("Gosho", attackerDamage, attackerHp);
            Warrior warrior2 = new Warrior("Pesho", defenderDamage, defenderHp);

            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Gosho", "Pesho"));
        }

        [Test]
        public void AttackWhenThisDamageIsMoreFromAttackerHp()
        {

            Warrior warrior = new Warrior("Gosho", 46, 50);
            Warrior warrior2 = new Warrior("Pesho", 20, 45);

            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            arena.Fight("Gosho","Pesho");

            Assert.AreEqual(30, warrior.HP);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void AttackWhenAttackerDamageIsMoreFromThisHp()
        {
            Warrior warrior = new Warrior("Gosho", 30, 50);
            Warrior warrior2 = new Warrior("Pesho", 20, 45);

            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            arena.Fight("Gosho", "Pesho");

            Assert.AreEqual(30, warrior.HP);
            Assert.AreEqual(15, warrior2.HP);
        }
    }
}
