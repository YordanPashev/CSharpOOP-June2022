using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int numberOfHeros = int.Parse(Console.ReadLine());
            
            while(heroes.Count < numberOfHeros)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                BaseHero hero = TryToCreateHero(heroType, heroName);

                if (hero != null)
                {
                    heroes.Add(hero);
                }

                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            Fight(heroes);
        }

        private static void Fight(List<BaseHero> heroes)
        {
            int bossPower = int.Parse(Console.ReadLine());

            int heroesPower = 0;

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }

            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero TryToCreateHero(string heroType, string heroName)
        {
            BaseHero hero = null;

            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }

            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }

            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }

            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
