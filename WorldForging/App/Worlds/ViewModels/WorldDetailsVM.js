app.controller('WorldDetailsVM', function ($scope, $http, $routeParams) {
    $http({
        method: 'GET',
        url: '/api/WorldsAPI',
        params: { id: $routeParams.id }
    }).then(function (response) {
        $scope.WorldDetails = response.data;
    });
});