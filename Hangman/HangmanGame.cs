namespace Hangman;


public class HangmanGame
{
    private readonly HashSet<char> _guessedLetters = new();
    private readonly string _wordToGuess;
    private string _word;
    private int _tries = 0;

    public HangmanGame(RandomWordGenerator generator)
    {
        _wordToGuess = generator.GetNext();
        _word = new string('_', _wordToGuess.Length);
    }

    public string GetWord()
    {
        return _word;
    }

    public GuessResponse Guess(char guess)
    {
        if (_guessedLetters.Contains(guess))
        {
            return new GuessResponse(_tries, GameState.LETTER_ALREADY_GUESSED, _word);
        }

        if (!_wordToGuess.Contains(guess))
        {
            _tries++;
            if (_tries == 10)
            {
                return new GuessResponse(_tries, GameState.LOOSE, _word);
            }
            return new GuessResponse(_tries, GameState.WRONG_GUESS, _word);
        }

        for (var i = 0; i < _word.Length; i++)
        {
            if (_wordToGuess[i] == guess)
            {
                _word = _word.Remove(i, 1).Insert(i, guess.ToString());
            }
        }

        if (_wordToGuess == _word)
        {
            return new GuessResponse(_tries, GameState.WON, _word);
        }

        _guessedLetters.Add(guess);
        return new GuessResponse(_tries, GameState.CORRECT_GUESS, _word);
    }
}