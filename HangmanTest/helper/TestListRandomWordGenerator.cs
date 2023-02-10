using Hangman;

namespace HangmanTest.helper;

public class TestListRandomWordGenerator : RandomWordGenerator
{
    private readonly string _word;


    public TestListRandomWordGenerator(string word)
    {
        _word = word;
    }
    
    public string GetNext()
    {
        return _word;
    }
}