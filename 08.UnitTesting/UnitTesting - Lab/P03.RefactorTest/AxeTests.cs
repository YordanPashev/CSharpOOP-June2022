using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private int health = 100;
        private int expieriance = 20;
        private Axe axe;
        private int attackPoints = 10;
        private int durabilityPoints = 10;


        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(health, expieriance);
            axe = new Axe(attackPoints, durabilityPoints);
        }

        [TearDown]
        public void tearDown()
        {
            durabilityPoints = 10;
        }

        [Test]
        public void Test_Is_Weapon_Loses_One_Point_Of_Its_Durability_After_An_Attack()
        {
            axe.Attack(this.dummy);

            Assert.That(axe.DurabilityPoints == 9, "Weapon must lose 1 durability point after each attack.");
        }

        [Test]
        public void Test_Attacking_With_Broken_Weapon_Should_Throw_Error()
        {
            durabilityPoints = 0;
            axe = new Axe(attackPoints, durabilityPoints);

            Assert.Throws<InvalidOperationException>(()
                => axe.Attack(this.dummy), "Axe is not broken.");
        }
    }
}