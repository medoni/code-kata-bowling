using BowlingCodeKata.BowlingGame;
using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.IntegrationTests;

[TestFixture]
[Category(TestCategories.Integration)]
public class FullStrikeTests
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
        for (var i = 0; i < 9; ++i)
        {
            Sut.Throwing.Throw(10);
        }
        Sut.Throwing.Throw(10);
        Sut.Throwing.Throw(10);
        Sut.Throwing.Throw(10);

        // assert
        Assert.That(Sut.IsFinished, Is.EqualTo(true));
        Assert.That(Sut.Scores.CalculateScore(), Is.EqualTo(300));
    }
}
