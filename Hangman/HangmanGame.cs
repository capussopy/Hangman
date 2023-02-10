namespace Hangman;

public class HangmanGame
{
    private readonly string _wordToGuess;
    private string _word;

    public HangmanGame(RandomWordGenerator generator)
    {
        _wordToGuess = generator.GetNext();
        _word = new string('_', _wordToGuess.Length);
    }

    public string GetWord()
    {
        return _word;
    }

    public void Guess(char guess)
    {
        for (var i = 0; i < _word.Length; i++)
        {
            if (_wordToGuess[i] == guess)
            {
                _word = _word.Remove(i, 1).Insert(i, guess.ToString());
            }
        }
    }
}