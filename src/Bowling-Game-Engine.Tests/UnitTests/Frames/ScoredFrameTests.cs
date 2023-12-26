using BowlingCodeKata.BowlingGame;

namespace BowlingCodeKata.Tests.UnitTests.Frames;

[TestFixture]
[Category(TestCategories.Unit)]
public class ScoredFrameTests
{
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 0)]
    [TestCase(2, 1, 1)]
    [TestCase(10, 8, 2)]
    [TestCase(20, 10)]
    public void CalculateSpecialAdditions_Should_Return_Correct_Value_When_Current_Throw_Is_Strike(
        int expectedAddition,
        params int[] nextThrows
    )
    {
        // arrange
        var frame = CreateBaseFrame(1, 10);
        var nextFrame = CreateBaseFrame(1, nextThrows);

        // act
        var additions = ScoredFrame.CalculateSpecialAdditions(
            frame,
            nextFrame
        );

        // assert
        Assert.That(additions, Is.EqualTo(expectedAddition));
    }

    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(8, 8, 2)]
    [TestCase(10, 10)]
    public void CalculateSpecialAdditions_Should_Return_Correct_Value_When_Current_Throw_Is_Spare(
        int expectedAddition,
        params int[] nextThrows
    )
    {
        // arrange
        var frame = CreateBaseFrame(1, 8, 2);
        var nextFrame = CreateBaseFrame(1, nextThrows);

        // act
        var additions = ScoredFrame.CalculateSpecialAdditions(
            frame,
            nextFrame
        );

        // assert
        Assert.That(additions, Is.EqualTo(expectedAddition));
    }

    [TestCase(0, 0, 0)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 1, 1)]
    [TestCase(0, 8, 2, 0)]
    [TestCase(0, 8, 2, 8)]
    [TestCase(10, 10, 10)]
    public void CalculateSpecialAdditionsLastThrow_Should_Return_Correct_Values(
        int expectedAddition,
        params int[] throws
    )
    {
        // act
        var additions = ScoredFrame.CalculateSpecialAdditionsLastThrow(throws);

        // assert
        Assert.That(additions, Is.EqualTo(expectedAddition));
    }

    private static BaseFrame CreateBaseFrame(int frameCount, params int[] throws)
    {
        var frame = BaseFrame.Create(frameCount);
        foreach (var throwCount in throws)
        {
            frame.AddThrow(throwCount);
        }

        return frame;
    }
}