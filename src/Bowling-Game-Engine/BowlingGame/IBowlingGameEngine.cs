namespace BowlingCodeKata.BowlingGame;

public interface IBowlingGameEngine
{
    IBowlingScoringEngine Scores { get; }
    IBowlingThrowEngine Throwing { get; }

    bool IsFinished { get; }
}
