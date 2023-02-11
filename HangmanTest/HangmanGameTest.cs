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

    [Test]
    public void AllowGuessLetterOnlyOnce()
    {
        _hangmanGame.Guess('N');

        var result = _hangmanGame.Guess('N');

        Assert.That(result.Result, Is.EqualTo(GuessResult.LETTER_ALREADY_GUESSED));
        Assert.That(result.Word, Is.EqualTo("__N___N"));
        Assert.That(result.Tries, Is.EqualTo(0));
    }


    [Test]
    public void DoAWrongGuess()
    {
        var result = _hangmanGame.Guess('X');

        Assert.That(result.Result, Is.EqualTo(GuessResult.WRONG_GUESS));
        Assert.That(result.Word, Is.EqualTo("_______"));
        Assert.That(result.Tries, Is.EqualTo(1));
    }
}