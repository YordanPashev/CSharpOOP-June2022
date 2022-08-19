using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Contracts
{
    public interface IWeapon
    {
        public int AttackPoints { get;  }

        public int DurabilityPoints { get;  }

        void Attack(IHero target);
    }
}
