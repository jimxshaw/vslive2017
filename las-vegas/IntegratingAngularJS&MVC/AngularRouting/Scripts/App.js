
var appMainModule = angular.module('appMain', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: '/Templates/Home.html',
            controller: 'homeViewModel'
        });
        $routeProvider.when('/customer/list', {
            templateUrl: '/Templates/CustomerList.html',
            controller: 'customerListViewModel'
        });
        $routeProvider.when('/customer/detail', {
            templateUrl: '/Templates/CustomerDetail.html',
            controller: 'customerDetailViewModel'
        });
        $routeProvider.otherwise({ redirectTo: '/' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

appMainModule.controller("indexViewModel", function ($scope, $http, $location) {
    $scope.headingCaption = 'Customer Maintenance';
});

appMainModule.controller("homeViewModel", function ($scope, $http, $location) {
    $scope.heading = 'This is the Home view.';
});

appMainModule.controller("customerListViewModel", function ($scope, $http, $location) {
    $scope.heading = 'Customer List View';

    $scope.people = [
    { FirstName: 'Miguel', LastName: 'Castro' },
    { FirstName: 'Rod', LastName: 'Paddock' },
    { FirstName: 'Sahil', LastName: 'Malik' },
    { FirstName: 'John', LastName: 'Petersen' },
    { FirstName: 'Kevin', LastName: 'Goff' }
    ];

    $scope.showPerson = function (person) {
        alert('You selected ' + person.FirstName + ' ' + person.LastName);
    }
});

appMainModule.controller("customerDetailViewModel", function ($scope, $http, $location) {
    $scope.heading = 'Customer Detail View';
});
