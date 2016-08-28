app.controller('WorldsVM', function ($scope, $http, $routeParams) {
    $http({
        method: 'GET',
        url: '/api/WorldsAPI'
    }).then(function (response) {
        $scope.Worlds = response.data;
    });
});