using System;
using System.Linq;

using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [TestCase("Pukachu", 11)]
    [TestCase("Zloto Kuche", int.MaxValue)]
    [TestCase("Bad boy", 12475443)]
    public void Test_Hero_Constructor_Should_Create_A_New_Hero
        (string name, int level)
    {
        Hero hero = new Hero(name, level);

        Assert.That(hero != null && hero.Name == name && hero.Level == level,
                    "The constructor does not create a new Hero with given values.");
    }

    [Test]
    public void Test_HeroRepository_Constructor_Should_Create_A_New_Repository()
    {
        Assert.That(heroRepository != null && heroRepository.Heroes.Count() == 0,
                    "The constructor does not create a new Hero Repository.");
    }

    [TestCase("Pukachu", 11)]
    [TestCase("Zloto Kuche", int.MaxValue)]
    [TestCase("Bad boy", 12475443)]
    public void Test_HeroRepository_Create_Method_Should_Add_Hero_To_The_Collection
        (string name, int level)
    {
        Hero hero = new Hero(name, level);

        heroRepository.Create(hero);

        foreach (Hero currHero in heroRepository.Heroes)
        {
            Assert.That(heroRepository.Heroes.Count() == 1 &&
                        hero.Name == currHero.Name &&
                        hero.Level == currHero.Level,
                       "The Create Method does not add new hero to the Repository.");
        }
    }

    [Test]
    public void Test_HeroRepository_Create_Method_Should_Throw_ArgumentNullException()
    {
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero),
                      "Must throw error because we the Hero is null.");
    }

    [TestCase("Pukachu", 11)]
    [TestCase("Zloto Kuche", int.MaxValue)]
    [TestCase("Bad boy", 12475443)]
    public void Test_HeroRepository_Create_Method_Should_Throw_Error_The_Herr_Already_Exist
        (string name, int level)
    {
        Hero hero = new Hero(name, level);

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero),
                       "Must throw error because the Hero already exist in the Repository.");
    }

    [TestCase(" ")]
    [TestCase(null)]
    public void Test_HeroRepository_Remove_Method_Should_Throw_ArgumentNullException
        (string heroName)
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(heroName),
                       "Must throw error because the Hero already name can not be null or white space.");
    }

    [TestCase("Pencho")]
    [TestCase("Dimitrichka")]
    public void Test_HeroRepository_Create_Method_Should_Return_False
        (string heroName)
    {
        bool expectedResult = false;
        bool actualResult = heroRepository.Remove(heroName);

        Assert.That(actualResult == expectedResult,
                       "Must return false because the hero does not exist in the Repository.");
    }

    [TestCase("Pukachu", 11)]
    [TestCase("Zloto Kuche", int.MaxValue)]
    [TestCase("Bad boy", 12475443)]
    public void Test_HeroRepository_Create_Method_Should_Return_True
        (string name, int level)
    {
        Hero hero = new Hero(name, level);
        heroRepository.Create(hero);
        bool expectedResult = true;
        bool actualResult = heroRepository.Remove(hero.Name);

        Assert.That(actualResult == expectedResult &&
                    heroRepository.Heroes.Count() == 0 &&
                    heroRepository.Heroes.Contains(hero) == false,
                    "The Remove method must return true because the Hero has been removed from the Repository."); ;
    }

    [TestCase("Pukachu", 11, "Lelq Cecka", 5, "Bako Ivan", int.MaxValue)]
    [TestCase("Zloto Kuche", 1, "Bad boy", 2, "Ministara na mafiotite", 3)]
    public void Test_HeroRepository_GetHeroWithHighestLevel_Must_Return_Highest_Level_Hero
        (string heroNameOne, int heroLevelOne,
         string heroNameTwo, int heroLevelTwo,
         string heroNameThree, int heroLevelThree)
    {
        Hero heroOne = new Hero(heroNameOne, heroLevelOne);
        Hero heroTwo = new Hero(heroNameTwo, heroLevelTwo);
        Hero heroThree = new Hero(heroNameThree, heroLevelThree);

        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        heroRepository.Create(heroThree);

        Hero expectedHeroWithHighestLevel = heroThree;
        Hero actualHeroWithHighestLevel = heroRepository.GetHeroWithHighestLevel();

        Assert.That(actualHeroWithHighestLevel.Name == expectedHeroWithHighestLevel.Name &&
                    actualHeroWithHighestLevel.Level == expectedHeroWithHighestLevel.Level,
                   $"The hero with highest level must be {expectedHeroWithHighestLevel.Name} - {expectedHeroWithHighestLevel.Level} lvl.");
    }

    [TestCase("Pukachu", 11, "Lelq Cecka", 5, "Bako Ivan", int.MaxValue)]
    [TestCase("Zloto Kuche", 1, "Bad boy", 2, "Ministara na mafiotite", 3)]
    public void Test_HeroRepository_GetHeroW_Must_Return_Chosen_Hero
        (string heroNameOne, int heroLevelOne,
         string heroNameTwo, int heroLevelTwo,
         string heroNameThree, int heroLevelThree)
    {
        Hero heroOne = new Hero(heroNameOne, heroLevelOne);
        Hero heroTwo = new Hero(heroNameTwo, heroLevelTwo);
        Hero heroThree = new Hero(heroNameThree, heroLevelThree);

        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        heroRepository.Create(heroThree);

        Hero expectedHero = heroTwo;

        Hero actualHero = heroRepository.GetHero(heroTwo.Name);

        Assert.That(actualHero.Name == expectedHero.Name &&
                    actualHero.Level == expectedHero.Level,
                    $"The hero must be with name {expectedHero.Name} and level {expectedHero.Level}.");
    }
}