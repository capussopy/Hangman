namespace Hangman;

public class GuessResponse
{
    public int Tries { get; }
    public GuessResult Result { get; }
    public string Word { get; }

    public GuessResponse(int tries, GuessResult result, string word)
    {
        Tries = tries;
        Result = result;
        Word = word;
    }
}