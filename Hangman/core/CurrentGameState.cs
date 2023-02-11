namespace Hangman;

public enum CurrentGameState
{
    Start,
    CorrectGuess,
    WrongGuess,
    LetterAlreadyGuessed,
    Won,
    Lost
}