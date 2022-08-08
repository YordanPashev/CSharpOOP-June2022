using System;
using System.Text;
using System.Linq;

using Heroes.Models.Map;
using Heroes.Repositories;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;

namespace Heroes.Core
{

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero { heroName } does not exist.");
            }

            IWeapon weapon = weapons.FindByName(weaponName);

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon { weaponName } does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero { heroName } is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero { heroName } can participate in battle using a { hero.Weapon.GetType().Name.ToString().ToLower() }.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = heroes.FindByName(name);

            if (hero != null)
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }

            if (type != "Barbarian" &&
                type != "Knight")
            {
                throw new InvalidOperationException($"Invalid hero type.");
            }

            string result = string.Empty;

            if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
                result = $"Successfully added Barbarian { name } to the collection.";
            }

            else if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                result = $"Successfully added Sir { name } to the collection.";
            }

            heroes.Add(hero);

            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = weapons.FindByName(name);

            if (weapon != null)
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }

            if (type != "Claymore" && type != "Mace")
            {
                throw new InvalidOperationException($"Invalid weapon type.");
            }

            string result = string.Empty;

            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }

            else if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }

            weapons.Add(weapon);

            return $"A { type.ToLower() } { name } is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder heroesInfo = new StringBuilder();

            foreach (IHero hero in heroes.Models.OrderBy(h => h.GetType().Name)
                                                .ThenByDescending(h => h.Health)
                                                .ThenBy(h => h.Name)
                                                .ToList())
            {
                heroesInfo.AppendLine($"{ hero.GetType().Name }: { hero.Name }")
                          .AppendLine($"--Health: { hero.Health }")
                          .AppendLine($"--Armour: { hero.Armour }")
                          .AppendLine(hero.Weapon == null ? "--Weapon: Unarmed"
                                                          : $"--Weapon: { hero.Weapon.Name }");
            }

            return heroesInfo.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();

            string fightResult = map.Fight(heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList());

            return fightResult;
        }
    }
}
