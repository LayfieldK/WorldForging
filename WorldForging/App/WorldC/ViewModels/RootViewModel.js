worldModule.controller("rootViewModel", function ($scope, worldService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    // This is the parent controller/viewmodel for 'productModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Product.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.worldService = worldService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "World Section";
    }

    $scope.worldList = function () {
        viewModelHelper.navigateTo('worlds/details');
    }

    

    initialize();
});
