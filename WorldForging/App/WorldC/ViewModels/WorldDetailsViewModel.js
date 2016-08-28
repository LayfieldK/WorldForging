worldModule.controller("worldDetailsViewModel", function ($scope, worldService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.productService = productService;

    var initialize = function () {
        $scope.refreshWorld($routeParams.worldId);
    }

    $scope.refreshProduct = function (productId) {
        viewModelHelper.apiGet('api/worldsapi/' + worldId, null,
            function (result) {
                worldService.worldId = worldId;
                $scope.WorldDetails = result.data;
            });
    }

    initialize();
});
