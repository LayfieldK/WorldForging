//var app = angular.module("main", ['ngRoute']).config(function ($routeProvider, $locationProvider) {
//    // configure the routing rules here
//    $routeProvider.when('/Worlds', {
//        templateUrl: '/App/Worlds/Views/WorldsView.html',
//        controller: 'WorldsVM'
//    })
//    .when('/Worlds/Details/:worldId', {
//        templateUrl: '/App/Worlds/Views/WorldDetailsView.html',
//        controller: 'WorldDetailsVM'
//    })
//    $routeProvider.otherwise({ redirectTo: '/' });;

//    // enable HTML5mode to disable hashbang urls
//    $locationProvider.html5Mode({
//        enabled: true,
//        requireBase: false
//    });
//});


var worldsModule = angular.module('worlds', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/worlds', { templateUrl: '/App/Worlds/Views/WorldsView.html', controller: 'WorldsVM' });
        $routeProvider.when('/worlds/details/:worldId', { templateUrl: '/App/Worlds/Views/WorldDetailsView.html', controller: 'WorldDetailsVM' });
        $routeProvider.otherwise({ redirectTo: '/worlds' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

worldsModule.factory('worldsService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.worldsService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var worldsService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.worldId = 0;

        return this;
    };
    myApp.worldsService = worldsService;
}(window.MyApp));