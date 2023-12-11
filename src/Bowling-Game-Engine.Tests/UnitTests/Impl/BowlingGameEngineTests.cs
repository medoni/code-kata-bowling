using BowlingCodeKata.BowlingGame;
using BowlingCodeKata.BowlingGame.Impl;
using Moq;

namespace BowlingCodeKata.Tests.UnitTests.Impl;

[TestFixture]
[Category(TestCategories.Unit)]
public class BowlingGameEngineTests
{
    private BowlingGameEngine Sut { get; set; }
    private Mock<IBowlingScoringEngine> ScoreEngineMock { get; set; }
    private Mock<IBowlingThrowEngine> ThrowEngineMock { get; set; }

    [SetUp]
    public void SetUp()
    {
        ScoreEngineMock = new Mock<IBowlingScoringEngine>();
        ThrowEngineMock = new Mock<IBowlingThrowEngine>();

        Sut = new BowlingGameEngine(
            ScoreEngineMock.Object,
            ThrowEngineMock.Object
        );
    }

    [Test]
    public void Scores_Should_Return_Correct_Value()
    {
        Assert.That(Sut.Scores, Is.EqualTo(ScoreEngineMock.Object));
    }

    [Test]
    public void Throwing_Should_Return_Correct_Value()
    {
        Assert.That(Sut.Throwing, Is.EqualTo(ThrowEngineMock.Object));
    }

    [Test]
    public void IsFinished_Should_Return_Correct_Value()
    {
        ThrowEngineMock
            .SetupGet(x => x.IsFinished)
            .Returns(true)
            .Verifiable();

        Assert.That(Sut.IsFinished, Is.True);
        ThrowEngineMock.VerifyAll();
    }
}
