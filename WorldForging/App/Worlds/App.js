var app = angular.module("main", ['ngRoute']).config(function ($routeProvider, $locationProvider) {
    // configure the routing rules here
    $routeProvider.when('/Worlds', {
        templateUrl: '/App/Worlds/Views/WorldsView.html',
        controller: 'WorldsVM'
    })
    .when('/Worlds/Details/:id', {
        templateUrl: '/App/Worlds/Views/WorldDetailsView.html',
        controller: 'WorldDetailsVM'
    })
    $routeProvider.otherwise({ redirectTo: '/' });;

    // enable HTML5mode to disable hashbang urls
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});