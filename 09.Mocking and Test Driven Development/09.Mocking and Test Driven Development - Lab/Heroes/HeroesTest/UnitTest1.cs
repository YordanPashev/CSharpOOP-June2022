namespace HeroesTest
{
    using Moq;
    using NUnit.Framework;

    using Heroes.Models;
    using Heroes.Models.Contracts;
    using Heroes.Repository.Contracts;

    public class Tests
    {

        [Test]
        public void Test_If_Hero_Gain_Experiance_When_Attack_Target()
        {
            IWeapon weapon = new Axe(100, 50);
            Hero hero = new Hero("Pepa", weapon);

            var heroes = new Mock<IRepository<IHero>>();
            heroes.Setup(h => h.AddItem(hero));

            heroes.Setup(h => h.Models.Count).Returns(1);
        }
    }
}