namespace Hangman;

public enum GameState
{
    LetterAlreadyGuessed,
    CorrectGuess,
    WrongGuess,
    Won,
    Loose
}