

using Hangman.core;

namespace Hangman.ui;

public interface IHangmanView
{
    void WelcomeMessage(IGameState state);
    char GetNextInput();
    void NextState(IGameState state);
}