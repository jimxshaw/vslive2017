"use strict";
exports.__esModule = true;
var vote_1 = require("./vote");
var Joke = (function () {
    function Joke(setup, punchline) {
        this.setup = setup;
        this.punchline = punchline;
        this.lols = new vote_1.Vote(0);
        this.groans = new vote_1.Vote(0);
    }
    Joke.prototype.groanCount = function () {
        return this.groans.voteCount();
    };
    Joke.prototype.addGroan = function () {
        this.groans.increment();
    };
    Joke.prototype.lolCount = function () {
        return this.lols.voteCount();
    };
    Joke.prototype.addLol = function () {
        this.lols.increment();
    };
    Joke.prototype.toString = function () {
        return this.setup + " " + this.punchline;
    };
    return Joke;
}());
exports.Joke = Joke;
