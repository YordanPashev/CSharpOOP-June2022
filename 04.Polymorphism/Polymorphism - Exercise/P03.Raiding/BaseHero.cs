using System;
using System.Collections.Generic;
using System.Text;

namespace Heros
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; protected  set; }
        public virtual int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
