
var worldModule = angular.module('world', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/worlds', { templateUrl: '/App/World/Views/WorldDetails.html', controller: 'worldDetailsViewModel' });
        $routeProvider.otherwise({ redirectTo: '/worlds' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

worldModule.factory('worldService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.worldService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var worldService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.worldId = 0;

        return this;
    };
    myApp.worldService = worldService;
}(window.MyApp));
