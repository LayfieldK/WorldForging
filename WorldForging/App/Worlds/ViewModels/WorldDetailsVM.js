//worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams) {
worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, /*worldId,*/ $stateParams) {

    $http({
        method: 'GET',
        url: '/api/WorldsAPI',
        //params: { worldId: worldId }
        params: { worldId: $stateParams.worldId }
    }).then(function (response) {
        $scope.WorldDetails = response.data;
    });

});



//worldsModule.component('worldDetails', {
//    bindings: {
//        worldId: '<',
//        WorldDetails: '<'
//    },
//    templateUrl: '/App/World/Views/WorldDetails.html',
//    controller: function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId) {
//        $http({
//            method: 'GET',
//            url: '/api/WorldsAPI',
//            params: { worldId: worldId }
//            //params: { worldId: $routeParams.worldId }
//        }).then(function (response) {
//            this.WorldDetails = response.data;
//        });

//    }
//});