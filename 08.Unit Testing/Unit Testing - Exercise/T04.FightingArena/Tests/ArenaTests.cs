namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Test_If_Constructor_Creates_A_New_List_Of_Warriors()
        {
            Assert.That(this.arena.Warriors, Is.EquivalentTo(new List<Warrior>()));
        }

        [TestCase("Sex Bok", 5121, 100)]
        [TestCase("Sex Bok", int.MaxValue, 100)]
        [TestCase("Sex Bok", 1, int.MaxValue)]
        public void Test_If_Enroll_Method_Add_Non_Enrolled_Warrior_To_the_List(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors.Any(w => w.Name == warrior.Name),
                        "This warrior has already been enrolled");
        }

        [TestCase("Sex Bok", 5121, 100)]
        [TestCase("Sex Bok", int.MaxValue, 100)]
        [TestCase("Sex Bok", 1, int.MaxValue)]
        public void Test_Enroll_Method_If_Warrior_Has_Already_Been_Enrolled_Throw_Error(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior),
                        "You trying to enroll non existing warrior on the list.");
        }

        [TestCase("Sex Bok", int.MaxValue, 100, "Miechu", int.MaxValue, 51, "Mara Shepova", int.MaxValue, 100)]
        [TestCase("Sex Bok", int.MaxValue, int.MaxValue, "Zloto kyche", 90, 31, "Zdravko Zhelyazkov", 124151, 100)]
        public void Test_If_Enrolled_Warriors_List_Adds_Warriors_Correctly(
             string firstWarriorName, int firstWarriorDamage, int firstWarriorHP,
             string secondWarriorName, int secondWarriorDamage, int secondWarriorHP,
             string thirdWarriorName, int thirdWarriorDamage, int thirdWarriorHP)
        {
            Warrior firstWarrior = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHP);
            Warrior secondWarrior = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHP);
            Warrior thirdWarrior = new Warrior(thirdWarriorName, thirdWarriorDamage, thirdWarriorHP);

            List<Warrior> expectedListOFWarriors = new List<Warrior> 
            {
                 firstWarrior,
                 secondWarrior,
                 thirdWarrior
            };

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            arena.Enroll(thirdWarrior);

            CollectionAssert.AreEqual(arena.Warriors, expectedListOFWarriors,
                        "The arena.warrios list is different from the expected list result.");
        }

        [TestCase("Sex Bok", int.MaxValue, 100, "Miechu", int.MaxValue, 51, "Mara Shepova", int.MaxValue, 100)]
        [TestCase("Sex Bok", int.MaxValue, int.MaxValue, "Zloto kyche", 90, 31, "Zdravko Zhelyazkov", 124151, 100)]
        public void Test_If_Counter_Works_Correctly(
             string firstWarriorName, int firstWarriorDamage, int firstWarriorHP,
             string secondWarriorName, int secondWarriorDamage, int secondWarriorHP,
             string thirdWarriorName, int thirdWarriorDamage, int thirdWarriorHP)
        {
            Warrior firstWarrior = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHP);
            Warrior secondWarrior = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHP);
            Warrior thirddWarrior = new Warrior(thirdWarriorName, thirdWarriorDamage, thirdWarriorHP);

            List<Warrior> expectedListOFWarriors = new List<Warrior>
            {
                 firstWarrior,
                 secondWarrior,
                 thirddWarrior
            };

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            arena.Enroll(thirddWarrior);

            Assert.AreEqual(arena.Warriors.Count, expectedListOFWarriors.Count,
                        "The counter does not works correctly.");
        }

        [TestCase("Sex Bok", int.MaxValue, 100, "Petko Voivoda", 987556, 1235)]
        [TestCase("Zloto kyche", 90, 31, "Bako Ivan", 981274, 127751)]
        public void Test_Fight_Method_If_Attacker_Has_Not_Been_Enrolled_Should_Throw_Error(
             string defenderName, int defenderDammage, int defenderHP,
             string attackerName, int attackerDamage, int attackerHP)
        {
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDammage, defenderHP);

            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => 
                        this.arena.Fight(attacker.Name, defender.Name),
                        "You are trying to get an enrolled attacker.");
        }

        [TestCase("Sex Bok", int.MaxValue, 100, "Petko Voivoda", 987556, 1235)]
        [TestCase("Zloto kyche", 90, 31, "Bako Ivan", 981274, 127751)]
        public void Test_Fight_Method_If_Deffender_Has_Not_Been_Enrolled_Should_Throw_Error(
             string defenderName, int defenderDammage, int defenderHP,
             string attackerName, int attackerDamage, int attackerHP)
        {
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDammage, defenderHP);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
                        this.arena.Fight(attacker.Name, defender.Name),
                        "You are trying to get an enrolled deffender.");
        }

        [TestCase("Miechu", int.MaxValue, int.MaxValue, "Zloto kyche", 90, 31)]
        [TestCase("Miechu", 12187654, 341, "Sex bok", 101, 31)]
        [TestCase("Sex bok", 102, 102, "Zloto kyche", 1, 101)]
        public void Test_Fight_Moethod_Is_Executing_The_Attack_Method(
             string attckerName, int attackerDamage, int attckerHP,
             string defenderName, int defenderDammage, int defenderHP)
        {
            Warrior attacker = new Warrior(attckerName, attackerDamage, attckerHP);
            Warrior defender = new Warrior(defenderName, defenderDammage, defenderHP);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(defender.HP == 0,
                       "The Fight method does not execute Attack method." +
                       "Expected result [HP of the defender must be 0.]");
        }
    }
}
