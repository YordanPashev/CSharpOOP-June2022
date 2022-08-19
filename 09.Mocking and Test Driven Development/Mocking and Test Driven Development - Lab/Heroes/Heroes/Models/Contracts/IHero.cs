namespace Heroes.Models.Contracts
{
    public interface IHero
    {
        public string Name { get; }

        public int Health { get; }

        void TakeAttack(int attackPoints);

        int GiveExperience();

        public bool IsDead();
    }
}
