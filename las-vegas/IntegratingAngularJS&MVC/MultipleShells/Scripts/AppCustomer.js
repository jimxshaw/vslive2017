
var appCustomerModule = angular.module('appCustomer', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/customer', {
            templateUrl: '/Templates/CustomerHome.html',
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
        // This route lets the URL stay CustomerIndex instead of being replaced by Customer
        // If it were changed to 'customer', refresh would break
        $routeProvider.when('/CustomerIndex.html', {
            templateUrl: '/Templates/CustomerHome.html',
            controller: 'homeViewModel'
        });
        $routeProvider.otherwise({ redirectTo: '/customer' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

appCustomerModule.controller("customerIndexViewModel", function ($scope, $http, $location, $window) {
    $scope.headingCaption = 'Customer Maintenance';

    $scope.ProductHome = function () {
        // assume it's a route in the current SPA
        //$location.path('/ProductIndex.html');

        // perform a full page-load
        $window.location.href = '/ProductIndex.html';
    }
});

appCustomerModule.controller("homeViewModel", function ($scope, $http, $location) {
    $scope.heading = 'This is the Customer Home view.';
});

appCustomerModule.controller("customerListViewModel", function ($scope, $http, $location) {
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

appCustomerModule.controller("customerDetailViewModel", function ($scope, $http, $location) {
    $scope.heading = 'Customer Detail View';
});
