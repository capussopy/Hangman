using Hangman;
using HangmanTest.helper;

namespace HangmanTest;

public class HangmanGameTestShould
{
    private const string TestWord = "HANGMAN";
    private RandomWordGenerator _generator; 
    private HangmanGame _hangmanGame;

    [SetUp]
    public void SetUp()
    {
        _generator = new TestListRandomWordGenerator(TestWord);
        _hangmanGame = new HangmanGame(_generator);
    }

    [Test]
    public void GetInitialHiddenWord()
    {
        var result = _hangmanGame.GetWord();

        Assert.That(result, Is.EqualTo("_______"));
    }

    [TestCase('H',"H______")]
    [TestCase('G',"___G___")]
    public void DoARightGuessAndUpdateWord(char guess, string expected)
    {
        _hangmanGame.Guess(guess);

        var result = _hangmanGame.GetWord();
        
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void DoTwoRightGuessesAndUpdateWord()
    {
        _hangmanGame.Guess('H');
        _hangmanGame.Guess('G');

        var result = _hangmanGame.GetWord();
        
        Assert.That(result, Is.EqualTo("H__G___"));
    }
    
    [Test]
    public void DoARightGuessWithAndUpdateTwoLetters()
    {
        _hangmanGame.Guess('N');

        var result = _hangmanGame.GetWord();
        
        Assert.That(result, Is.EqualTo("__N___N"));
    }
    
}