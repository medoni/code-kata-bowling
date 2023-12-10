using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.UnitTests.Impl;

[TestFixture]
[Category(TestCategories.Unit)]
public class BowlingGameEngineTests
{
    private BowlingGameEngine Sut { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sut = new BowlingGameEngine();
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
