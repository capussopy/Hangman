using Hangman;


namespace HangmanTest;

public class RandomWordGeneratorTestShould
{
    [Test]
    public void ReturnARandomWordInUpperCase()
    {
        var generator = new RandomWordGenerator();

        var result = generator.GetNext();
        
        Assert.That(result, Is.InstanceOf(typeof(string)));
        Assert.That(result, Is.EqualTo(result.ToUpper()));
    }
}

