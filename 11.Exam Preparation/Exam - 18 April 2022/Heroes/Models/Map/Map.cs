using System.Linq;
using System.Collections.Generic;

using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = new List<Knight>();
            List<Barbarian> barbarians = new List<Barbarian>();

            foreach (IHero hero in players)
            {
                if (hero.IsAlive)
                {
                    if (hero is Knight knight)
                    {
                        knights.Add(knight);
                    }

                    else if (hero is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                }
            }

            bool isFightOver = false;
            string result = string.Empty;

            while (!isFightOver)
            {
                foreach (Knight knight in knights.Where(k => k.IsAlive))
                {

                    foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        int dmg = knight.Weapon.DoDamage();
                        barbarian.TakeDamage(dmg);
                    }
                }

                if (!barbarians.Any(b => b.IsAlive))
                {
                    result = $"The knights took { knights.Where(k => !k.IsAlive).Count() } casualties but won the battle.";
                    isFightOver = true;
                    break;
                }

                foreach (Barbarian barbarian in barbarians.Where(k => k.IsAlive))
                {

                    foreach (Knight knight in knights.Where(b => b.IsAlive))
                    {
                        int dmg = barbarian.Weapon.DoDamage();
                        knight.TakeDamage(dmg);
                    }
                }

                if (!knights.Any(b => b.IsAlive))
                {
                    result = $"The barbarians took { barbarians.Where(k => !k.IsAlive).Count() } casualties but won the battle.";
                    isFightOver = true;
                    break;
                }
            }

            return result;
        }
    }
}
