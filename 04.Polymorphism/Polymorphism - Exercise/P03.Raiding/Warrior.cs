using System;
using System.Collections.Generic;
using System.Text;

namespace Heros
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
