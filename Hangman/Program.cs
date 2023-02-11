// See https://aka.ms/new-console-template for more information

using Hangman.controller;
using Hangman.core;
using Hangman.ui;
using Hangman.word_generator;

var view = new ConsoleHangmanView();
var game = new HangmanGame(new TextFileRandomWordGenerator());
var controller = new HangmanController(game, view);

controller.Play();