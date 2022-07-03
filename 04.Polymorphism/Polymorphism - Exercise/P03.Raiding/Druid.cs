using System;
using System.Collections.Generic;
using System.Text;

namespace Heros
{
    public  class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            Power = 80;
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
