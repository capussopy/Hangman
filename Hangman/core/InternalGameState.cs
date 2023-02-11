namespace Hangman.core;

public class InternalGameState : IGameState
{
    private int _usedTries = 0;
    private int _remainingTries;
    private CurrentGameState _state = CurrentGameState.Start;
    private string _word;

    public InternalGameState(string word, int numberOfTries)
    {
        _word = word;
        _remainingTries = numberOfTries;
    }

    public IGameState WithAlreadyGuessed()
    {
        _state = CurrentGameState.LetterAlreadyGuessed;
        return this;
    }

    public IGameState WithWrongGuess()
    {
        _usedTries++;
        _remainingTries--;
        _state = _remainingTries == 0 ? CurrentGameState.Lost : CurrentGameState.WrongGuess;
        return this;
    }

    public IGameState WithCorrectGuess(string word)
    {
        _word = word;
        _state = IsGameWon() ? CurrentGameState.Won : CurrentGameState.CorrectGuess;
        return this;
    }

    private bool IsGameWon()
    {
        return !_word.Contains('_');
    }

    public int GetUsedTries()
    {
        return _usedTries;
    }

    public int GetRemainingTries()
    {
        return _remainingTries;
    }

    public CurrentGameState GetState()
    {
        return _state;
    }

    public string GetWord()
    {
        return _word;
    }
}