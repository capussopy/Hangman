using Hangman.core;

namespace Hangman;

public class HangmanGame
{
    private const int NumberOfTries = 10;
    private readonly string _solutionWord;
    private readonly InternalGameState _state;
    private readonly HashSet<char> _guessedLetters = new();
    private string _word;

    public HangmanGame(RandomWordGenerator generator)
    {
        _solutionWord = generator.GetNext();
        _word = new string('_', _solutionWord.Length);
        _state = new InternalGameState(_word, NumberOfTries);
    }

    public IGameState GetState()
    {
        return _state;
    }


    public IGameState Guess(char guess)
    {
        if (IsLetterAlreadyGuessed(guess))
        {
            return _state.WithAlreadyGuessed();
        }

        if (IsGuessWrong(guess))
        {
            return _state.WithWrongGuess();
        }

        UpdateWord(guess);
        _guessedLetters.Add(guess);
        return _state.WithCorrectGuess(_word);
    }

    private bool IsLetterAlreadyGuessed(char guess)
    {
        return _guessedLetters.Contains(guess);
    }

    private bool IsGuessWrong(char guess)
    {
        return !_solutionWord.Contains(guess);
    }

    private void UpdateWord(char guess)
    {
        for (var i = 0; i < _solutionWord.Length; i++)
        {
            if (_solutionWord[i] == guess)
            {
                _word = _word.Remove(i, 1).Insert(i, guess.ToString());
            }
        }
    }
}