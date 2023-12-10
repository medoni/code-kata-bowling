using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.UnitTests.Impl;

[TestFixture]
[Category(TestCategories.Unit)]
public class BowlingScoreEngineTests
{
    private BowlingScoreEngine Sut { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sut = new BowlingScoreEngine();
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
