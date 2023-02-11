namespace Hangman;

public class GuessResponse
{
    private const int NumberOfTries = 10;
    public int UsedTries { get; }
    public int RemainingTries { get; }
    public GameState State { get; }
    public string Word { get; }

    public GuessResponse(int usedTries, GameState state, string word)
    {
        UsedTries = usedTries;
        RemainingTries = NumberOfTries - usedTries;
        State = state;
        Word = word;
    }
}