using Hangman.core;
using Hangman.ui;

namespace Hangman.controller;

public class HangmanController
{
    private readonly HangmanGame _game;
    private readonly IHangmanView _view;


    public HangmanController(HangmanGame game, IHangmanView view)
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