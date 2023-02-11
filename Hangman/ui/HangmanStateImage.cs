namespace Hangman.ui;

public static class HangmanStateImage
{
    private static readonly Dictionary<int, string> Images = new()
    {
        { 1, State1 },
        { 2, State2 },
        { 3, State3 },
        { 4, State4 },
        { 5, State5 },
        { 6, State6 },
        { 7, State7 },
        { 8, State8 },
        { 9, State9 },
        { 10, State10 },
    };

    private const string State1 = @"
    
      
      
      
    
____|_____
";

    private const string State2 = @"
   
    | 
    |  
    |  
    |   
____|_____
";

    private const string State3 = @"
   
    |/  
    |  
    |  
    |   
____|_____
";

    private const string State4 = @"
    _____
    |/  
    |  
    |  
    |   
____|_____
";

    private const string State5 = @"
    _____
    |/  |
    |  
    |  
    |  
____|_____
";

    private const string State6 = @"
    _____
    |/  |
    |   O
    |  
    |   
____|_____
";

    private const string State7 = @"
    _____
    |/  |
    |   O
    |   |
    |   
____|_____
 ";


    private const string State8 = @"
    _____
    |/  |
    |   O
    |   |´
    |   
____|_____
 ";

    private const string State9 = @"
    _____
    |/  |
    |   O
    |  `|´
    |   
____|_____
";

    private const string State10 = @"
    _____
    |/  |
    |   O
    |  `|´
    |   ^
____|_____
";

    public static string Get(int image)
    {
        return Images[image];
    }
}