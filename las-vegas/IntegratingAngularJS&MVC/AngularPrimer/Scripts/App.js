
var appMainModule = angular.module('appMain', []);

appMainModule.controller("homePageViewModel", function ($scope, $http, $location) {

    $scope.headingCaption = 'This is a list of people:';

    $scope.people = [
        { FirstName: 'Miguel', LastName: 'Castro' },
        { FirstName: 'Andrew', LastName: 'Brust' },
        { FirstName: 'Brian', LastName: 'Noyes' },
        { FirstName: 'John', LastName: 'Petersen' },
        { FirstName: 'Brian', LastName: 'Randell' },
        { FirstName: 'Gus', LastName: 'Emery' }
    ];

    $scope.showPerson = function (person) {
        alert('You selected ' + person.FirstName + ' ' + person.LastName);
        //person.FirstName = "Miguel";
        person.LastName = "Castro";
    }
});
