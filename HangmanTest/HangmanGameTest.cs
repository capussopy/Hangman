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

    [TestCase('H', "H______")]
    [TestCase('G', "___G___")]
    public void DoARightGuessAndUpdateWord(char guess, string expected)
    {
        var result = _hangmanGame.Guess(guess);
        
        Assert.That(result.State, Is.EqualTo(GameState.CORRECT_GUESS));
        Assert.That(result.Word, Is.EqualTo(expected));
        Assert.That(result.UsedTries, Is.EqualTo(0));
        Assert.That(result.RemainingTries, Is.EqualTo(10));
    }

    [Test]
    public void DoTwoRightGuessesAndUpdateWord()
    {
        _hangmanGame.Guess('H');
        
        var result = _hangmanGame.Guess('G');

        Assert.That(result.State, Is.EqualTo(GameState.CORRECT_GUESS));
        Assert.That(result.Word, Is.EqualTo("H__G___"));
        Assert.That(result.UsedTries, Is.EqualTo(0));
        Assert.That(result.RemainingTries, Is.EqualTo(10));
    }

    [Test]
    public void DoARightGuessWithAndUpdateTwoLetters()
    {
        var result = _hangmanGame.Guess('N');

        Assert.That(result.State, Is.EqualTo(GameState.CORRECT_GUESS));
        Assert.That(result.Word, Is.EqualTo("__N___N"));
        Assert.That(result.UsedTries, Is.EqualTo(0));
        Assert.That(result.RemainingTries, Is.EqualTo(10));
    }

    [Test]
    public void AllowGuessLetterOnlyOnce()
    {
        _hangmanGame.Guess('N');

        var result = _hangmanGame.Guess('N');

        Assert.That(result.State, Is.EqualTo(GameState.LETTER_ALREADY_GUESSED));
        Assert.That(result.Word, Is.EqualTo("__N___N"));
        Assert.That(result.UsedTries, Is.EqualTo(0));
        Assert.That(result.RemainingTries, Is.EqualTo(10));
    }


    [Test]
    public void DoAWrongGuess()
    {
        var result = _hangmanGame.Guess('X');

        Assert.That(result.State, Is.EqualTo(GameState.WRONG_GUESS));
        Assert.That(result.Word, Is.EqualTo("_______"));
        Assert.That(result.UsedTries, Is.EqualTo(1));
        Assert.That(result.RemainingTries, Is.EqualTo(9));
    }
    
    [Test]
    public void WinAGameWithoutWrongGuesses()
    {
        _hangmanGame.Guess('H');
        _hangmanGame.Guess('A');
        _hangmanGame.Guess('N');
        _hangmanGame.Guess('G');
        
        var result = _hangmanGame.Guess('M');
        
        Assert.That(result.State, Is.EqualTo(GameState.WON));
        Assert.That(result.Word, Is.EqualTo("HANGMAN"));
        Assert.That(result.UsedTries, Is.EqualTo(0));
        Assert.That(result.RemainingTries, Is.EqualTo(10));
    }
    
    public void WinAGameWithWrongGuesses()
    {
        _hangmanGame.Guess('H');
        _hangmanGame.Guess('B');
        _hangmanGame.Guess('X');
        _hangmanGame.Guess('A');
        _hangmanGame.Guess('N');
        _hangmanGame.Guess('G');
        
        var result = _hangmanGame.Guess('M');
        
        Assert.That(result.State, Is.EqualTo(GameState.WON));
        Assert.That(result.Word, Is.EqualTo("HANGMAN"));
        Assert.That(result.UsedTries, Is.EqualTo(2));
        Assert.That(result.RemainingTries, Is.EqualTo(8));
    }
    
    [Test]
    public void LoseAGameWithoutCorrectGuesses()
    {
        _hangmanGame.Guess('B');
        _hangmanGame.Guess('C');
        _hangmanGame.Guess('D');
        _hangmanGame.Guess('E');
        _hangmanGame.Guess('F');
        _hangmanGame.Guess('I');
        _hangmanGame.Guess('J');
        _hangmanGame.Guess('K');
        _hangmanGame.Guess('L');

        var result = _hangmanGame.Guess('O');
        
        Assert.That(result.State, Is.EqualTo(GameState.LOOSE));
        Assert.That(result.Word, Is.EqualTo("_______"));
        Assert.That(result.UsedTries, Is.EqualTo(10));
        Assert.That(result.RemainingTries, Is.EqualTo(0));
    }
    
    [Test]
    public void LoseAGameWithCorrectGuesses()
    {
        _hangmanGame.Guess('H');
        _hangmanGame.Guess('A');
        _hangmanGame.Guess('B');
        _hangmanGame.Guess('C');
        _hangmanGame.Guess('D');
        _hangmanGame.Guess('E');
        _hangmanGame.Guess('F');
        _hangmanGame.Guess('I');
        _hangmanGame.Guess('J');
        _hangmanGame.Guess('K');
        _hangmanGame.Guess('L');

        var result = _hangmanGame.Guess('O');
        
        Assert.That(result.State, Is.EqualTo(GameState.LOOSE));
        Assert.That(result.Word, Is.EqualTo("HA___A_"));
        Assert.That(result.UsedTries, Is.EqualTo(10));
        Assert.That(result.RemainingTries, Is.EqualTo(0));
    }
}