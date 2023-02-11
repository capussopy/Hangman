namespace Hangman;

public interface IGameState
{
    int GetUsedTries();
    int GetRemainingTries();
    CurrentGameState GetState();
    string GetWord();
}