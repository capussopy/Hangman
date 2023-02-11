using Hangman.ui;

namespace Hangman;

public class HangmanController
{
    private readonly HangmanGame _game;
    private readonly HangmanView _view;


    public HangmanController(HangmanGame game, HangmanView view)
    {
        _game = game;
        _view = view;
    }

    public void Play()
    {
        _view.WelcomeMessage(_game.GetState());

        while (_game.IsGameRunning())
        {
            var guess = _view.GetNextInput();
            var state =  _game.Guess(guess);
            _view.NextState(state);
        }
    }
}