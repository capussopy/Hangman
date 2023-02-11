// See https://aka.ms/new-console-template for more information

using Hangman;
using Hangman.controller;
using Hangman.core;
using Hangman.ui;

var view = new ConsoleHangmanView();
var game = new HangmanGame(new ListRandomWordGenerator());
var controller = new HangmanController(game, view);

controller.Play();