namespace Hangman;

public class GuessResponse
{
    private const int NumberOfTries = 10;
    public  HashSet<char> GuessedLetters { get; } = new();
    public int UsedTries { get; private set; }
    public int RemainingTries { get; private set; }
    public GameState State { get; set; }
    public string Word { get; set; }

    public GuessResponse(int usedTries, GameState state, string word)
    {
        UsedTries = usedTries;
        RemainingTries = NumberOfTries - usedTries;
        State = state;
        Word = word;
    }

    public GuessResponse(int numberOfTries)
    {
        RemainingTries = numberOfTries;
    }

    public void WrongTry()
    {
        UsedTries++;
        RemainingTries--;
    }
}