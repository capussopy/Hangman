using System.Text;

namespace Hangman.word_generator;

public class TextFileRandomWordGenerator: RandomWordGenerator
{
    private readonly Random _random = new();
    private readonly List<string> _words = new();

    public TextFileRandomWordGenerator()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        foreach (var word in File.ReadLines($@"{path}\words.txt", Encoding.UTF8))
        {
          _words.Add(word);
        }
    }


    public string GetNext()
    {
        var index = _random.Next(0, _words.Count);
        return _words[index];
    }
}