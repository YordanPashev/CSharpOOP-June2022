namespace WarCroft.Entities.Characters
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory;

    public class Warrior : Character, IAttacker 
    {
        private const double initialHealth = 100;
        private const double initialArmour = 50;
        private const double abilityPoints = 40;

        public Warrior(string name)
            : base(name, initialHealth, initialArmour, abilityPoints, new Satchel()) { }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
