// See https://aka.ms/new-console-template for more information

using Hangman;
using Hangman.ui;

var view = new HangmanView();
var game = new HangmanGame(new ListRandomWordGenerator());
var controller = new HangmanController(game, view);

controller.Play();