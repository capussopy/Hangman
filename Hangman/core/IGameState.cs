namespace Hangman.core;

public interface IGameState
{
    int GetUsedTries();
    int GetRemainingTries();
    CurrentGameState GetState();
    string GetWord();
}