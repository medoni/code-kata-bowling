using BowlingCodeKata.BowlingGame;
using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.IntegrationTests;

[TestFixture]
[Category(TestCategories.Integration)]
public class ZeroThrowsTests
{
    private IBowlingGameEngine Sut { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sut = BowlingGameEngine.Create();
    }

    [Test]
    public void Throwing_10_Times_Should_Finish_Game_With_Correct_Score()
    {
        // arrange
        for (var i = 0; i < 10; ++i)
        {
            Sut.Throwing.Throw(0);
            Sut.Throwing.Throw(0);
        }

        // assert
        Assert.That(Sut.IsFinished, Is.EqualTo(true));
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(0));
    }
}
