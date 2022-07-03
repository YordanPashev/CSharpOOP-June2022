using System;
using System.Collections.Generic;
using System.Text;

namespace Heros
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            Power = 80;
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
