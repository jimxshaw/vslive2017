"use strict";
exports.__esModule = true;
var Vote = (function () {
    function Vote(count) {
        this.count = count;
    }
    Vote.prototype.voteCount = function () {
        return this.count;
    };
    Vote.prototype.increment = function () {
        this.count++;
    };
    Vote.prototype.decrement = function () {
        this.count--;
    };
    return Vote;
}());
exports.Vote = Vote;
