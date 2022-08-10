namespace WarCroft.Entities.Characters
{
    using System;

    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory;

    public class Priest : Character, IHealer
    {
        private const double initialHealth = 50;
        private const double initialArmour = 25;
        private const double abilityPoints = 40;

        public Priest(string name)
            : base(name, initialHealth, initialArmour, abilityPoints, new Backpack()) { }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
