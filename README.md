# Bowling Code Kata

This Bowling Code Kata is designed to practice and improve your coding skills by implementing a bowling scoring system.

## Description

The goal of this kata is to create a program that calculates the score of a bowling game based on the rolls of a player. The rules for scoring in bowling can be found [Wikipedia Traditional scoring](https://en.wikipedia.org/wiki/Ten-pin_bowling#Traditional_scoring). Your task is to write a function or set of functions that take in a series of rolls and output the total score for the game.

### Instructions
- Write a class `Game` with following abstract methods
    - A method for roll pins
    - A method for calculating score

## Implementation

```mermaid
---
title: Game engine overview
---
classDiagram
    class IBowlingGameEngine {
        <<Interface>>
        +IBowlingScoringEngine Scores
        +IBowlingThrowEngine Throwing
        +bool IsFinished
    }

    class IBowlingThrowEngine {
        <<Interface>>
        +Throw(int count)
        +bool IsFinished
    }

    class IBowlingScoringEngine {
        <<Interface>>
        +int CalculateScore()
    }

    IBowlingGameEngine --* IBowlingScoringEngine
    IBowlingGameEngine --* IBowlingThrowEngine
```

The game engine class
```csharp
/// <summary>
/// Definition of a bowling game engine
/// </summary>
public interface IBowlingGameEngine
{
    /// <summary>
    /// Information about the current score
    /// </summary>
    IBowlingScoringEngine Scores { get; }

    /// <summary>
    /// Information about the current throwing 
    /// </summary>
    IBowlingThrowEngine Throwing { get; }

    /// <summary>
    /// True when the game has been finished.
    /// </summary>
    bool IsFinished { get; }
}
```
Source: [IBowlingGameEngine.cs](src/Bowling-Game-Engine/BowlingGame/IBowlingGameEngine.cs)<br>
Implementation: [BowlingGameEngine.cs](src/Bowling-Game-Engine/BowlingGame/Impl/BowlingGameEngine.cs)

The throwing engine class
```csharp
/// <summary>
/// Definition for throwing pins for a bowling game
/// </summary>
public interface IBowlingThrowEngine
{
    /// <summary>
    /// Throws the given count of pins
    /// </summary>
    /// <exception cref="BowlingException">Thrown when the game has been finished.</exception>
    void Throw(int count);

    /// <summary>
    /// Returns true if the game has been finished.
    /// </summary>
    bool IsFinished { get; }
}
```
Source: [IBowlingThrowEngine.cs](src/Bowling-Game-Engine/BowlingGame/IBowlingThrowEngine.cs)<br>
Implementation: [BowlingThrowEngine.cs](src/Bowling-Game-Engine/BowlingGame/Impl/BowlingThrowEngine.cs)

The scoring engine class
```csharp
/// <summary>
/// Definition for calculating score for a bowling game
/// </summary>
public interface IBowlingScoringEngine
{
    /// <summary>
    /// Calculates the current score
    /// </summary>
    int CalculateScore();
}
```
Source: [IBowlingThrowEngine.cs](src/Bowling-Game-Engine/BowlingGame/IBowlingScoringEngine.cs)<br>
Implementation: [BowlingThrowEngine.cs](src/Bowling-Game-Engine/BowlingGame/Impl/BowlingScoreEngine.cs)

## How to Use
TODO

## Ressources
- [Ten-pin bowling](https://en.wikipedia.org/wiki/Ten-pin_bowling)
