namespace Hangman;

public enum GameState
{
    LETTER_ALREADY_GUESSED,
    CORRECT_GUESS,
    WRONG_GUESS,
    WON,
    LOOSE
}