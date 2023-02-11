namespace Hangman;

public class HangmanGame
{
    private const int NumberOfTries = 10;
    private readonly string _wordToGuess;
    private readonly GuessResponse _state = new(NumberOfTries);

    public HangmanGame(RandomWordGenerator generator)
    {
        _wordToGuess = generator.GetNext();
        _state.Word = new string('_', _wordToGuess.Length);
    }

    public string GetWord()
    {
        return _state.Word;
    }

    public GuessResponse Guess(char guess)
    {
        if (_state.GuessedLetters.Contains(guess))
        {
            _state.State = GameState.LetterAlreadyGuessed;
            return _state;
        }

        if (!_wordToGuess.Contains(guess))
        {
            _state.WrongTry();
            if (_state.UsedTries == NumberOfTries)
            {
                _state.State = GameState.Loose;
                return _state;
            }

            _state.State = GameState.WrongGuess;
            return _state;
        }

        UpdateWord(guess);

        if (_wordToGuess == _state.Word)
        {
            _state.State = GameState.Won;
            return _state;
        }

        _state.GuessedLetters.Add(guess);
        _state.State = GameState.CorrectGuess;
        return _state;
    }

    private void UpdateWord(char guess)
    {
        for (var i = 0; i < _wordToGuess.Length; i++)
        {
            if (_wordToGuess[i] == guess)
            {
                _state.Word = _state.Word.Remove(i, 1).Insert(i, guess.ToString());
            }
        }
    }
}