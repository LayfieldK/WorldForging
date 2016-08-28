worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    $http({
        method: 'GET',
        url: '/api/WorldsAPI',
        params: { worldId: $routeParams.worldId }
    }).then(function (response) {
        $scope.WorldDetails = response.data;
    });

});