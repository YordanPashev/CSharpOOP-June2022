using System;
using System.Collections.Generic;
using System.Text;

namespace Heros
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
