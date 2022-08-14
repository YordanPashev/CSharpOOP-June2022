using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_Weapon_Constructor_Must_Create_A_New_Weapon()
            {
                string name = "bazdugan";
                double price = 11.2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(name, price, destructionLevel);

                Assert.That(weapon != null && weapon.Name == name &&
                            weapon.Price == price && weapon.DestructionLevel == destructionLevel);
            }


            [Test]
            public void Test_Weapon_Price_Must_Throw_Error()
            {
                string name = "bazdugan";
                double price = -1;
                int destructionLevel = 15;

                Assert.Throws<ArgumentException>(() => new Weapon(name, price, destructionLevel));
            }

            [Test]
            public void Test_Weapon_IncreaseDestructionLevel_Increase_By_One()
            {
                string name = "bazdugan";
                double price = 2;
                int destructionLevel = 15;

                int expectedResult = 16;
                Weapon weapon = new Weapon(name, price, destructionLevel);
                weapon.IncreaseDestructionLevel();

                Assert.That(weapon.DestructionLevel == expectedResult);
            }

            [Test]
            public void Test_Weapon_IsNuclear_Must_Return_True()
            {
                string name = "bazdugan";
                double price = 2;
                int destructionLevel = 9;

                Weapon weapon = new Weapon(name, price, destructionLevel);
                weapon.IncreaseDestructionLevel();

                Assert.That(weapon.IsNuclear == true);
            }

            [Test]
            public void Test_Weapon_IsNuclear_Must_Return_False()
            {
                string name = "bazdugan";
                double price = 2;
                int destructionLevel = 9;

                Weapon weapon = new Weapon(name, price, destructionLevel);

                Assert.That(weapon.IsNuclear == false);
            }

            [Test]
            public void Test_Planet_Constructor_Must_Create_New_Planet()
            {
                string name = "Pluton";
                double budget = 2;
                Planet planet = new Planet(name, budget);

                Assert.That(planet != null && planet.Name == name &&
                            planet.Weapons.Count == 0);
            }

            [TestCase("")]
            [TestCase(null)]
            public void Test_Planet_Name_Must_Throw_Error(string name)
            {
                double budget = 2;

                Assert.Throws<ArgumentException>(() => new Planet(name, budget));
            }

            [Test]
            public void Test_Plamet_Budget_Must_Throw_Error()
            {
                string name = "Mars";
                double budget = -2;

                Assert.Throws<ArgumentException>(() => new Planet(name, budget));
            }

            [Test]
            public void Test_Planet_MilitaryPowerRatio()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);

                string weaponName = "bazdugan";
                double price = 2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(weaponName, price, destructionLevel);
                double expectedResult = 15;

                planet.AddWeapon(weapon);
                double actualResult = planet.MilitaryPowerRatio;

                Assert.That(actualResult == expectedResult);
            }

            [Test]
            public void Test_Planet_Profit()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                double expectedResult = 4;

                planet.Profit(2);
                double actualResult = planet.Budget;

                Assert.That(actualResult == expectedResult);
            }


            [Test]
            public void Test_Planet_SpendFunds()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                double expectedResult = 1;

                planet.SpendFunds(1);
                double actualResult = planet.Budget;

                Assert.That(actualResult == expectedResult);
            }

            [Test]
            public void Test_Planet_SpendFunds_Must_Throw_Error()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(3));
            }

            [Test]
            public void Test_Planet_AddWepon()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                double expectedResult = 1;

                string weaponName = "bazdugan";
                double price = 2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(weaponName, price, destructionLevel);
                planet.AddWeapon(weapon);

                Assert.That(planet.Weapons.Count == expectedResult);
            }

            [Test]
            public void Test_Planet_AddWepon_Must_Throw_Error()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);

                string weaponName = "bazdugan";
                double price = 2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(weaponName, price, destructionLevel);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            [Test]
            public void Test_Planet_RemoeWepon()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                double expectedResult = 0;

                string weaponName = "bazdugan";
                double price = 2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(weaponName, price, destructionLevel);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);

                Assert.That(planet.Weapons.Count == expectedResult);
            }

            [Test]
            public void Test_Planet_RemoveWepon_Two()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                int expectedResult = 1;

                string weaponName = "bazdugan";
                double price = 2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(weaponName, price, destructionLevel);

                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Sabq");

                Assert.That(planet.Weapons.Count == expectedResult);
            }

            [Test]
            public void Test_Planet_Upgrade_Must_Throw_Error()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);
                string fakeWeaponName = "tamagochi";

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon(fakeWeaponName));
            }

            [Test]
            public void Test_Planet_Upgrade_Must_Increace_Weaopns_Destruction_Level()
            {
                string planetName = "Mars";
                double budget = 2;
                Planet planet = new Planet(planetName, budget);

                string weaponName = "bazdugan";
                double price = 2;
                int destructionLevel = 15;
                Weapon weapon = new Weapon(weaponName, price, destructionLevel);

                int expectedResult = 16;
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weaponName);

                Assert.That(weapon.DestructionLevel == expectedResult);
            }

            [Test]
            public void Test_Planet_DestructOpponetMust_Throw_Error()
            {
                string planetNameOne = "Mars";
                double budgetOne = 2;
                Planet planetOne = new Planet(planetNameOne, budgetOne);

                string weaponNameOne = "bazdugan";
                double priceOne = 2;
                int destructionLevelOne = 4;
                Weapon weaponOne = new Weapon(weaponNameOne, priceOne, destructionLevelOne);

                planetOne.AddWeapon(weaponOne);

                string planetNameTwo = "Jupiter";
                double budgetTwo = 2;
                Planet planetTwo = new Planet(planetNameTwo, budgetTwo);

                string weaponNameTwo = "sabq";
                double priceTwo = 2;
                int destructionLevelTwo = 5;
                Weapon weaponTwo = new Weapon(weaponNameTwo, priceTwo, destructionLevelTwo);
                planetTwo.AddWeapon(weaponTwo);

                Assert.Throws<InvalidOperationException>(() => planetOne.DestructOpponent(planetTwo));
            }

            [Test]
            public void Test_Planet_DestructOpponetMust()
            {
                string planetNameOne = "Mars";
                double budgetOne = 2;
                Planet planetOne = new Planet(planetNameOne, budgetOne);

                string weaponNameOne = "bazdugan";
                double priceOne = 2;
                int destructionLevelOne = 121;
                Weapon weaponOne = new Weapon(weaponNameOne, priceOne, destructionLevelOne);

                planetOne.AddWeapon(weaponOne);

                string planetNameTwo = "Jupiter";
                double budgetTwo = 2;
                Planet planetTwo = new Planet(planetNameTwo, budgetTwo);

                string weaponNameTwo = "sabq";
                double priceTwo = 2;
                int destructionLevelTwo = 5;
                Weapon weaponTwo = new Weapon(weaponNameTwo, priceTwo, destructionLevelTwo);
                planetTwo.AddWeapon(weaponTwo);

                string expectedResult = $"{planetTwo.Name} is destructed!";
                string actualResult = planetOne.DestructOpponent(planetTwo);
                Assert.That(actualResult == expectedResult);
            }
        }
    }
}
