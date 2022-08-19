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
            var heroes = new Mock<IRepository<IHero>>();
            int expectedHeroesCount = 3;
            Hero heroOne = new Hero("Pepa", weapon);
            Hero heroTwo = new Hero("Conka", weapon);
            Hero heroThree = new Hero("Penchu", weapon);

            heroes.Setup(h => h.AddItem(heroOne));
            heroes.Setup(h => h.AddItem(heroTwo));
            heroes.Setup(h => h.AddItem(heroThree));

            heroes.Setup(h => h.Models.Count).Returns(expectedHeroesCount);
        }
    }
}
