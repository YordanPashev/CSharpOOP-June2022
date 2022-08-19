namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Test_If_Constructor_Creates_A_List_Of_Warriors()
        {
            string name = "Bako Ivan";
            int damage = 50;
            int hp = 50;
            Warrior warrior = new Warrior(name, damage,  hp);

            Assert.That(name == warrior.Name && 
                        damage == warrior.Damage &&
                        hp == warrior.HP,
                        "One or more values are not valid.");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_If_Tries_To_Set_Invalid_Name_Should_Throw_Error(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(invalidName, 50, 100),
                                            "You are trying to se a valid name.");
        }

        [TestCase(0)]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        public void Test_If_Tries_To_Set_Invalid_Damage_Value_Should_Throw_Error(int invalidDamage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Bako Ivan", invalidDamage, 100),
                                            "You are trying to se a valid damage value.");
        }

        [TestCase(-123182762)]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        public void Test_If_Tries_To_Set_Invalid_HP_value_Should_Throw_Error(int invalidHP)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Bako Ivan", 50, invalidHP),
                                            "You are trying to se a valid HP value.");
        }

        [TestCase(30, 50)]
        [TestCase(0, 50)]
        [TestCase(1, 50)]
        public void Test_If_Warrior_Tries_To_Attack_While_Has_Less_Than_Min_Allowed_HP_Should_Throw_Error
              (int invalidAttackerHP, int validDefenderHP)
        {
            Warrior attacker = new Warrior("Bacho Kolio", 50, invalidAttackerHP);
            Warrior defender = new Warrior("Ko iskash be, bastun!", 50, validDefenderHP);

            Assert.Throws<InvalidOperationException>(() =>
                            attacker.Attack(defender),
                            "Attacker has enough HP to attack.");
            
        }

        [TestCase(50, 30)]
        [TestCase(110, 0)]
        [TestCase(78, 1)]
        public void Test_If_Warrior_Tries_To_Attack_And_Deffender_Has_Less_Than_Min_Allowed_HP_Should_Throw_Error
              (int validAttackerHP, int invalidDefenderHP)
        {
            Warrior attacker = new Warrior("Bacho Kolio", 50,validAttackerHP);
            Warrior defender = new Warrior("Ko iskash be, bastun!", 50, invalidDefenderHP);

            Assert.Throws<InvalidOperationException>(() =>
                            attacker.Attack(defender),
                            "Defender has enough HP to attack.");
        }

        [Test]
        public void Test_If_Warrior_Tries_To_Attack_Stronger_Enemy_Shloud_Throw_Error()
        {
            Warrior attacker = new Warrior("Bacho Kolio", 50, 49);
            Warrior defender = new Warrior("Ko iskash be, bastun!", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
                            attacker.Attack(defender),
                            "The Attacker is stronger than defender.");
        }

        [Test]
        public void Test_If_Attacker_Succeed_Decrees_Woriors_HPs()
        {
            Warrior attacker = new Warrior("Bacho Kolio", 50, 100);
            Warrior defender = new Warrior("Ko iskash be, bastun!", 30, 100);
            int expectedAttackerHp = attacker.HP - defender.Damage;
            int expectedDefenderHp = defender.HP - attacker.Damage;

            if (expectedDefenderHp < 0)
            {
                expectedDefenderHp = 0;
            }

            attacker.Attack(defender);

            Assert.That(expectedAttackerHp == attacker.HP && expectedDefenderHp == defender.HP,
                       "The logic and calculations in Attack Method are wrong.");
        }

        [Test]
        public void Test_If_After_an_Attack_Defender_HP_Is_Negative_Set_HP_To_Zero()
        {
            Warrior attacker = new Warrior("Bacho Kolio", 50, 100);
            Warrior defender = new Warrior("Ko iskash be, bastun!", 30, 40);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP, "The HP value is wrong. It must be 0.");
        }
    }
}