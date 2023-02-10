namespace Hangman;

public class RandomWordGenerator
{
    private readonly Random _random = new();
    private readonly List<string> _words = new()
    {
        "COMPLAINT",
        "INITIATIVE",
        "PHILOSOPHY",
        "RECOGNITION",
        "FOUNDATION",
        "MARKETING",
        "COLLECTION",
        "APARTMENT",
        "RELATIONSHIP",
        "INTRODUCTION"
    };


    public string GetNext()
    {
        var index = _random.Next(0, _words.Count);
        return _words[index];
    }
}