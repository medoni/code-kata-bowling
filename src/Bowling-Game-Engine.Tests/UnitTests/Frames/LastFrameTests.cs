using BowlingCodeKata.BowlingGame;

namespace BowlingCodeKata.Tests.UnitTests.Frames;

[TestFixture]
[Category(TestCategories.Unit)]
public class LastFrameTests
{
    private LastFrame Sut { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sut = new LastFrame();
    }

    [Test]
    public void IsLastFrame_Should_Return_True()
    {
        Assert.That(Sut.IsLastFrame, Is.True);
    }

    [TestCase(true)]
    [TestCase(true, 8)]
    [TestCase(true, 8, 2)]
    [TestCase(false, 1, 2)]
    [TestCase(true, 10)]
    [TestCase(true, 10, 10)]
    [TestCase(false, 10, 10, 8)]
    [TestCase(false, 10, 10, 10)]
    public void CanThrow_Should_Return_Correct_Values(
        bool expectedResult,
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(Sut.CanThrow, Is.EqualTo(expectedResult));
    }

    [TestCase(false)]
    [TestCase(false, 8)]
    [TestCase(false, 8, 2)]
    [TestCase(true, 1, 2)]
    [TestCase(false, 10)]
    [TestCase(false, 10, 1)]
    [TestCase(false, 10, 10)]
    [TestCase(true, 10, 10, 1)]
    [TestCase(true, 10, 10, 10)]
    public void ThrowFinished_Should_Return_Correct_Values(
        bool expectedResult,
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(Sut.ThrowFinished, Is.EqualTo(expectedResult));
    }

    [TestCase(1)]
    [TestCase(1, 2)]
    [TestCase(8, 2)]
    [TestCase(10)]
    [TestCase(8, 2, 1)]
    [TestCase(8, 2, 10)]
    [TestCase(10, 10, 1)]
    [TestCase(10, 10, 10)]
    public void AddThrow_Should_Add_Throw(
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(
            Sut.Throws.Select(x => x.Count),
            Is.EqualTo(throws)
        );
    }

    [TestCase(1, 2, 3)]
    [TestCase(10, 2, 4, 6)]
    [TestCase(10, 10, 10, 1)]
    public void AddThrow_Should_Throw_Exception_When_Finished(
        params int[] throws
    )
    {
        Assert.That(
            () =>
            {
                foreach (var throwCount in throws)
                {
                    Sut.AddThrow(throwCount);
                }
            },
            Throws.TypeOf<InvalidOperationException>()
        );
    }
}
