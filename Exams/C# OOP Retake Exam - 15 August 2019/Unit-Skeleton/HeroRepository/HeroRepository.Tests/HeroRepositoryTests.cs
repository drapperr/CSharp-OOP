using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void ConstructorShouldCreateAnEmptyRepository()
    {
        HeroRepository heroRepository=new HeroRepository();
        Assert.That(heroRepository.Heroes.Count,Is.EqualTo(0));
    }

    [Test]
    public void CreateMethodShouldThrowArgumentNullExceptionIfParameterIsNull()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateMethodShouldThrowInvalidOperationExceptionIfHeroWithThisNameIsExist()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("Pesho",1));

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(new Hero("Pesho", 33)));
    }

    [Test]
    public void CreateMethodShouldCreateSuccessfully()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 1);

        string result=heroRepository.Create(hero);
        string expectedResult = "Successfully added hero Ivan with level 1";

        Assert.That(result,Is.EqualTo(expectedResult));
        Assert.That(heroRepository.GetHero("Ivan"),Is.EqualTo(hero));
        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(1));
    }

    [TestCase(null)]
    [TestCase(" ")]
    public void RemoveMethodShouldThrowArgumentNullExceptionWithNullOrWhitespace(string value)
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(value));
    }

    [Test]
    public void RemoveMethodShouldReturnTrueIfHeroIsExist()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 1);

        heroRepository.Create(hero);

        bool result = heroRepository.Remove("George");

        Assert.That(result,Is.EqualTo(false));
    }

    [Test]
    public void RemoveMethodShouldReturnFalseIfHeroIsNotExist()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 1);

        heroRepository.Create(hero);

        bool result = heroRepository.Remove("Ivan");

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 1);
        Hero hero2 = new Hero("George", 120);
        Hero hero3 = new Hero("Edward", 13);
        Hero hero4 = new Hero("Lucy", 14);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);

        Hero expectedResult = heroRepository.GetHeroWithHighestLevel();

        Assert.That(expectedResult,Is.EqualTo(hero2));
    }

    [Test]
    public void GetHeroShouldReturnCorrectlyThisHero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 1);
        heroRepository.Create(hero);

        Hero expectedResult = heroRepository.GetHero("Ivan");

        Assert.That(expectedResult, Is.EqualTo(hero));
    }

    [Test]
    public void GetHeroShouldReturnNullIfHeroIsNotExist()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 1);
        heroRepository.Create(hero);

        Hero expectedResult = heroRepository.GetHero("George");

        Assert.That(expectedResult, Is.EqualTo(null));
    }
} 