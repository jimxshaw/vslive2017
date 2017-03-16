
var appProductModule = angular.module('appProduct', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/product', {
            templateUrl: '/Templates/ProductHome.html',
            controller: 'homeViewModel'
        });
        $routeProvider.when('/product/list', {
            templateUrl: '/Templates/ProductList.html',
            controller: 'productListViewModel'
        });
        $routeProvider.when('/product/detail', {
            templateUrl: '/Templates/ProductDetail.html',
            controller: 'productDetailViewModel'
        });
        $routeProvider.otherwise({ redirectTo: '/product' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

appProductModule.controller("productIndexViewModel", function ($scope, $http, $location, $window) {
    $scope.headingCaption = 'Product Maintenance';

    $scope.CustomerHome = function () {
        $window.location.href = '/CustomerIndex.html';
    }
});

appProductModule.controller("homeViewModel", function ($scope, $http, $location) {
    $scope.heading = 'This is the Product Home view.';
});

appProductModule.controller("productListViewModel", function ($scope, $http, $location) {
    $scope.heading = 'Product List View';

    $scope.products = [
    { Description: 'Macallan 12', Price: 52.00 },
    { Description: 'Lagavulin 16', Price: 95.00 },
    { Description: 'Balvinie Caribbean Cask', Price: 55.00 },
    { Description: 'Johnny Walker Double Black', Price: 42.00 }
    ];

    $scope.showPerson = function (person) {
        alert('You selected ' + person.FirstName + ' ' + person.LastName);
    }
});

appProductModule.controller("productDetailViewModel", function ($scope, $http, $location) {
    $scope.heading = 'Product Detail View';
});
