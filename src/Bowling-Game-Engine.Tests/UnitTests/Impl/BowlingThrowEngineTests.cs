using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.UnitTests.Impl;

[TestFixture]
[Category(TestCategories.Unit)]
public class BowlingThrowEngineTests
{
    private BowlingThrowEngine Sut { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sut = new BowlingThrowEngine();
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
