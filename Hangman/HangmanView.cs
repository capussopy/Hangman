namespace Hangman;

public class HangmanView
{
    private readonly Dictionary<CurrentGameState, Action<IGameState>> _functionsDictionary;

    public HangmanView()
    {
        _functionsDictionary = new Dictionary<CurrentGameState, Action<IGameState>>
        {
            { CurrentGameState.CorrectGuess, ShowCorrectGuessMessage },
            { CurrentGameState.WrongGuess, ShowWrongGuessMessage },
            { CurrentGameState.Won, ShowWonMessage },
            { CurrentGameState.Loose, ShowLooseMessage },
        };
    }


    public void WelcomeMessage(IGameState state)
    {
        Console.WriteLine("Welcome to Hangman the Game");
        Console.WriteLine($"You have {state.GetRemainingTries()} tries to find the correct word");
        Console.WriteLine($"Word: {state.GetWord()}");
    }

    public char GetNextInput()
    {
        Console.Write("What letter you guess: ");
        var input = Console.ReadKey().KeyChar;
        Console.WriteLine();
        if (IsInvalidInput(input))
        {
            Console.WriteLine("Invalid input!");
            return GetNextInput();
        }
        return input;
    }

    private bool IsInvalidInput(char input)
    {
        return !char.IsLetter(input) || !char.IsUpper(input);
    }

    public void NextState(IGameState state)
    {
        _functionsDictionary[state.GetState()](state);
    }

    private void ShowCorrectGuessMessage(IGameState state)
    {
        Console.WriteLine("Your guess was right");
        Console.WriteLine($"Word: {state.GetWord()}");
    }

    private void ShowWrongGuessMessage(IGameState state)
    {
        Console.WriteLine($"Your guess was wrong. You have {state.GetRemainingTries()} tries left");
        Console.WriteLine("Very Bad image here :(");
        Console.WriteLine($"Word: {state.GetWord()}");
    }

    private void ShowLooseMessage(IGameState state)
    {
        Console.WriteLine($"You have loose this game!");
    }

    private void ShowWonMessage(IGameState state)
    {
        Console.WriteLine($"You have won! The word is {state.GetWord()}");
    }
}