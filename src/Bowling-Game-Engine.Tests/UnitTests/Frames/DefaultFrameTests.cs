using BowlingCodeKata.BowlingGame;

namespace BowlingCodeKata.Tests.UnitTests.Frames;

[TestFixture]
[Category(TestCategories.Unit)]
public class DefaultFrameTests
{
    private DefaultFrame Sut { get; set; }

    [SetUp]
    public void SetUp()
    {
        Sut = new DefaultFrame();
    }

    [Test]
    public void IsLastFrame_Should_Return_False()
    {
        Assert.That(Sut.IsLastFrame, Is.False);
    }

    [TestCase()]
    [TestCase(8)]
    [TestCase(8, 2)]
    [TestCase(1, 2)]
    [TestCase(10)]
    public void CanThrow_Should_Return_Correct_Values(
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(Sut.CanThrow, Is.True);
    }

    [TestCase(false)]
    [TestCase(false, 8)]
    [TestCase(true, 8, 2)]
    [TestCase(true, 1, 2)]
    [TestCase(true, 10)]
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
    [TestCase(10)]
    public void AddThrow_Should_Add_Throw(
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(
            Sut.Throws,
            Is.EqualTo(throws)
        );
    }

    [TestCase(1, 2, 3)]
    [TestCase(10, 2)]
    [TestCase(8, 2, 1)]
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

    [TestCase(true, 10)]
    [TestCase(false, 0, 0)]
    [TestCase(false, 8, 0)]
    [TestCase(false, 8, 2)]
    [TestCase(false, 5)]
    public void IsStrike_Should_Return_Correct_Value(
        bool expectedValue,
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(Sut.IsStrike, Is.EqualTo(expectedValue));
    }

    [TestCase(true, 8, 2)]
    [TestCase(false, 0, 0)]
    [TestCase(false, 8, 0)]
    [TestCase(false, 10)]
    [TestCase(false, 5)]
    public void IsSpare_Should_Return_Correct_Value(
        bool expectedValue,
        params int[] throws
    )
    {
        foreach (var throwCount in throws)
        {
            Sut.AddThrow(throwCount);
        }

        Assert.That(Sut.IsSpare, Is.EqualTo(expectedValue));
    }
}
