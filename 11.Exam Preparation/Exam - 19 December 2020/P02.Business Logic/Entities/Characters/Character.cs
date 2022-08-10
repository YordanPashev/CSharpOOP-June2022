using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        private IBag bag;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.Health = health;
            this.BaseHealth = health;
            this.Armor = armor;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health 
        {   get => this.health;
            set 
            {
                if (value <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }

                else if(value > BaseHealth)
                {
                    health = BaseHealth;
                }

                this.health = value;
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            private set
            {

                if (value <= 0)
                {
                    armor = 0;
                }

                else if (value > BaseArmor)
                {
                    armor = BaseArmor;
                }

                this.armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag 
        { 
            get => this.bag;
            private set 
            {
                this.bag = value;
            } 
        }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            double dmg = hitPoints;

            if (this.Armor - dmg < 0)
            {
                dmg -= this.Armor;

                this.Armor = 0;
                if (Health - dmg <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }

                else
                {
                    Health -= dmg;
                }
            }

            else
            {
                this.Armor = this.Armor - dmg;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }
    }
}