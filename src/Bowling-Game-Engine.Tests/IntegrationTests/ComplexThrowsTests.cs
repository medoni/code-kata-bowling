using BowlingCodeKata.BowlingGame;
using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.IntegrationTests;

[TestFixture]
[Category(TestCategories.Integration)]
public class ComplexThrowsTests
{
    private IBowlingGameEngine Sut { get; set; }

    [OneTimeSetUp]
    public void SetUp()
    {
        Sut = BowlingGameEngine.Create();
    }

    [Test]
    [Order(1)]
    public void Throw_1()
    {
        // arrange
        Sut.Throwing.Throw(7);
        Sut.Throwing.Throw(2);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(9));
    }

    [Test]
    [Order(2)]
    public void Throw_2()
    {
        // arrange
        Sut.Throwing.Throw(3);
        Sut.Throwing.Throw(5);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(17));
    }

    [Test]
    [Order(3)]
    public void Throw_3()
    {
        // arrange
        Sut.Throwing.Throw(9);
        Sut.Throwing.Throw(1);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(27));
    }

    [Test]
    [Order(4)]
    public void Throw_4()
    {
        // arrange
        Sut.Throwing.Throw(3);
        Sut.Throwing.Throw(6);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(39));
    }

    [Test]
    [Order(5)]
    public void Throw_5()
    {
        // arrange
        Sut.Throwing.Throw(0);
        Sut.Throwing.Throw(4);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(43));
    }

    [Test]
    [Order(6)]
    public void Throw_6()
    {
        // arrange
        Sut.Throwing.Throw(6);
        Sut.Throwing.Throw(1);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(50));
    }

    [Test]
    [Order(7)]
    public void Throw_7()
    {
        // arrange
        Sut.Throwing.Throw(10);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(60));
    }

    [Test]
    [Order(8)]
    public void Throw_8()
    {
        // arrange
        Sut.Throwing.Throw(5);
        Sut.Throwing.Throw(4);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(78));
    }

    [Test]
    [Order(9)]
    public void Throw_9()
    {
        // arrange
        Sut.Throwing.Throw(8);
        Sut.Throwing.Throw(1);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(87));
    }

    [Test]
    [Order(10)]
    public void Throw_10()
    {
        // arrange
        Sut.Throwing.Throw(9);
        Sut.Throwing.Throw(1);
        Sut.Throwing.Throw(7);

        // assert
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(104));
        Assert.That(Sut.IsFinished, Is.True);
    }
}
