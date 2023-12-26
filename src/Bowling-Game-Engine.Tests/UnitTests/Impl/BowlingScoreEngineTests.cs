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

    [TestCase(0, 0)]
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(2, 1, 1)]
    public void First_Throw_Should_Return_Correct_Value(
        int expectedScore,
        params int[] throws
    )
    {
        // arrange
        Frames.Add(CreateFrame(1, throws));

        // act
        var score = Sut.CalculateScore();

        // assert
        Assert.That(score, Is.EqualTo(expectedScore));
    }

    [TestCase(0, 0)]
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(2, 1, 1)]
    public void Second_Throw_Should_Return_Correct_Value(
        int expectedScore,
        params int[] throws
    )
    {
        // arrange
        Frames.Add(CreateFrame(1, [0, 0]));
        Frames.Add(CreateFrame(2, throws));

        // act
        var score = Sut.CalculateScore();

        // assert
        Assert.That(score, Is.EqualTo(expectedScore));
    }

    [TestCase(10, 0)]
    [TestCase(10, 0, 0)]
    [TestCase(12, 1, 0)]
    [TestCase(11, 0, 1)]
    [TestCase(13, 1, 1)]
    public void Second_Throw_After_Spare_Should_Return_Correct_Value(
        int expectedScore,
        params int[] throws
    )
    {
        // arrange
        Frames.Add(CreateFrame(1, [2, 8]));
        Frames.Add(CreateFrame(2, throws));

        // act
        var score = Sut.CalculateScore();

        // assert
        Assert.That(score, Is.EqualTo(expectedScore));
    }

    [TestCase(10, 0)]
    [TestCase(10, 0, 0)]
    [TestCase(12, 1, 0)]
    [TestCase(12, 0, 1)]
    [TestCase(14, 1, 1)]
    public void Second_Throw_After_Strike_Should_Return_Correct_Value(
        int expectedScore,
        params int[] throws
    )
    {
        // arrange
        Frames.Add(CreateFrame(1, [10]));
        Frames.Add(CreateFrame(2, throws));

        // act
        var score = Sut.CalculateScore();

        // assert
        Assert.That(score, Is.EqualTo(expectedScore));
    }

    private static BaseFrame CreateFrame(int frameCount, int[] throws)
    {
        var frame = BaseFrame.Create(frameCount);
        foreach (var throwCount in throws)
        {
            frame.AddThrow(throwCount);
        }
        return frame;
    }
}
