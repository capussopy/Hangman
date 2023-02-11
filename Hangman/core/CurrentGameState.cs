namespace Hangman.core;

public enum CurrentGameState
{
    Start,
    CorrectGuess,
    WrongGuess,
    LetterAlreadyGuessed,
    Won,
    Lost
}