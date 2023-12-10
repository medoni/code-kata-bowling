namespace BowlingCodeKata.BowlingGame;

public interface IBowlingThrowEngine
{
    void Throw(int count);
    bool IsFinished { get; }
}
