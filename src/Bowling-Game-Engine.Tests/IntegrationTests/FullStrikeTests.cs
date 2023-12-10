using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.IntegrationTests;

[TestFixture]
[Category(TestCategories.Integration)]
public class FullStrikeTests
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
