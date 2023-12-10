using BowlingCodeKata.BowlingGame;
using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.UnitTests.Impl;

[TestFixture]
[Category(TestCategories.Unit)]
public class BowlingScoreEngineTests
{
    private BowlingScoreEngine Sut { get; set; }
    private FramesList Frames { get; set; }

    [SetUp]
    public void SetUp()
    {
        Frames = new FramesList();

        Sut = new BowlingScoreEngine(Frames);
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
