using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(100, 20);
        }

        [Test]
        public void Test_Is_Weapon_Loses_One_Point_Of_Its_Durability_After_An_Attack()
        {
            Axe axe = new Axe(0, 10);

            axe.Attack(this.dummy);

            Assert.AreEqual(axe.DurabilityPoints, 9);
        }

        [Test]
        public void Test_Attacking_With_Broken_Weapon_Should_Throw_Error()
        {
            Axe axe = new Axe(0, 0);


            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(this.dummy);
            });
        }
    }
}