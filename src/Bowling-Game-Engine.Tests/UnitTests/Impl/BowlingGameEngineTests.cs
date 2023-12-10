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
    public void Test()
    {
        // arrange

        // act

        // assert
        Assert.Fail();
    }
}
