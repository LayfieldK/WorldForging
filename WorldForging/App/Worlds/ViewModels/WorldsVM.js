worldsModule.controller('WorldsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    $http({
        method: 'GET',
        url: '/api/WorldsAPI'
    }).then(function (response) {
        $scope.Worlds = response.data;
    });


    $scope.showWorld = function (world) {
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('worlds/details/' + world.WorldId);
    }

});