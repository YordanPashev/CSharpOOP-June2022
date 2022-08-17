namespace Heroes.Models
{

    using Heroes.Models.Contracts;

    public class Hero : IHero
    {
        private string name;
        private int experience;
        private IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            this.name = name;
            this.experience = 10;
            this.weapon = weapon;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Experience
        {
            get { return this.experience; }
        }

        public IWeapon Weapon
        {
            get { return this.weapon; }
        }

        public int Health => throw new System.NotImplementedException();

        public void Attack(IHero target)
        {
            this.weapon.Attack(target);

            if (target.IsDead())
            {
                this.experience += target.GiveExperience();
            }
        }

        public int GiveExperience()
        {
            throw new System.NotImplementedException();
        }

        public bool IsDead()
        {
            throw new System.NotImplementedException();
        }

        public void TakeAttack(int attackPoints)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
            => $"Hero {this.Name} -> EXP {this.Experience} -> Weapon{this.Name}";
    }
}
