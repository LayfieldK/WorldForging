worldsModule.controller("rootViewModel", function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    // This is the parent controller/viewmodel for 'productModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Product.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.worldsService = worldsService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Worlds Section";
    }

    $scope.worldsList = function () {
        viewModelHelper.navigateTo('worlds/');
    }

    $scope.showWorld = function () {
        if (worldsService.worldId != 0) {
            $scope.flags.shownFromList = false;
            viewModelHelper.navigateTo('worlds/details/' + worldsService.worldId);
        }
    }

    initialize();
});
