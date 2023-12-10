using BowlingCodeKata.BowlingGame;
using BowlingCodeKata.BowlingGame.Impl;

namespace BowlingCodeKata.Tests.UnitTests.Impl;

[TestFixture]
[Category(TestCategories.Unit)]
public class BowlingThrowEngineTests
{
    private BowlingThrowEngine Sut { get; set; }

    private FramesList Frames { get; set; }

    [SetUp]
    public void SetUp()
    {
        Frames = new FramesList();

        Sut = new BowlingThrowEngine(Frames);
    }

    [Test]
    public void Throwing_With_2_Throws_Should_Finish_Frame()
    {
        // act
        Sut.Throw(1);
        Sut.Throw(2);

        // assert
        Assert.That(
            Frames.SelectMany(x => x.Throws.Select(y => y.Count)),
            Is.EqualTo(new[] { 1, 2 })
        );
        Assert.That(Sut.ThrowFinished, Is.True);
    }

    [Test]
    public void Throwing_Strike_Should_Finish_Frame()
    {
        // act
        Sut.Throw(10);

        // assert
        Assert.That(
            Frames.SelectMany(x => x.Throws.Select(y => y.Count)),
            Is.EqualTo(new[] { 10 })
        );
        Assert.That(Sut.ThrowFinished, Is.True);
    }

    [Test]
    public void Throwing_Spare_Should_Finish_Frame()
    {
        // act
        Sut.Throw(8);
        Sut.Throw(2);

        // assert
        Assert.That(
            Frames.SelectMany(x => x.Throws.Select(y => y.Count)),
            Is.EqualTo(new[] { 10 })
        );
        Assert.That(Sut.ThrowFinished, Is.True);
    }

    [Test]
    public void Throwing_3_Times_Should_Throw_Exception_When_Not_Last_Round(
        [Range(1, 9)]
        int round
    )
    {
        // arrange
        for (var i = 0; i < round; ++i)
        {
            Sut.Throw(1);
            Sut.Throw(2);
        }

        // act
        Assert.That(
            () =>
            {
                Sut.Throw(10);
                Sut.Throw(10);
                Sut.Throw(2);
            },
            Throws.TypeOf<BowlingException>()
        );
    }

    [Test]
    public void Throwing_3_Times_In_Last_Frame_Should_Finish_Frame()
    {
        // arrange
        for (var i = 0; i < 9; ++i)
        {
            Sut.Throw(1);
            Sut.Throw(2);
        }

        // act
        Sut.Throw(10);
        Sut.Throw(10);
        Sut.Throw(2);

        // arrange
        Assert.That(
            Frames.Last().Throws.Select(x => x.Count),
            Is.EqualTo(new[] { 10, 10, 2 })
        );
        Assert.That(Sut.ThrowFinished, Is.True);
    }
}
