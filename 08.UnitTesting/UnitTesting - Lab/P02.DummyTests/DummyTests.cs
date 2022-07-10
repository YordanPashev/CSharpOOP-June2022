using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int health = 100;
        private int expieriance = 20;
        private int attackPoints = 10;

        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(health, expieriance);
        }

        [TearDown]
        public void tearDown()
        {
            health = 100;
            expieriance = 20;
            attackPoints = 10;
        }

        [Test]
        public void Test_Is_Dummy_Loses_Health_If_Has_Been_Attacked()
        {
            int initialHealt = dummy.Health;
  
            dummy.TakeAttack(attackPoints);

            Assert.That(dummy.Health == 90, $"Dummy's health must be {initialHealt - attackPoints} after the attack.");
        }

        [Test]
        public void Test_If_Try_To_Attack_Dead_Dummy_Throw_Error()
        {
            attackPoints = dummy.Health;

            dummy.TakeAttack(attackPoints);

            Assert.Throws<InvalidOperationException>(()
                => dummy.TakeAttack(attackPoints), "Dummy is not dead (its health is more than 0).");
        }

        [Test]
        public void Test_Dead_Dummy_Could_Give_Expirience()
        {
            attackPoints = dummy.Health;

            dummy.TakeAttack(attackPoints);
            Assert.That(dummy.GiveExperience() == expieriance, "Dummy it not dead and can not give expirience.");
        }

        [Test]
        public void Test_If_Alive_Dummy_Tries_To_Give_Expirience_Throw_Error()
        {
            Assert.That(() => { dummy.GiveExperience(); }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
