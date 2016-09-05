//worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams) {
worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, $uibModal, /*worldId,*/ $stateParams) {

    

    $scope.LoadWorldDetails = function (worldId) {
        $http({
            method: 'GET',
            url: '/api/WorldsAPI',
            //params: { worldId: worldId }
            params: { worldId: worldId }
        }).then(function (response) {
            $scope.WorldDetails = response.data;
        });
    }
    

    $scope.showAddCharacterForm = function () {


        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/App/Characters/Views/AddCharacterView.html',
            controller: 'AddCharacterVM',
            controllerAs: '$ctrl',
            size: 'lg',
            resolve: {
                worldId: function () {
                    return $stateParams.worldId;
                }
            }

        });

        modalInstance.result.then(function () {
            $scope.LoadWorldDetails($stateParams.worldId);
        });

    }

    $scope.LoadWorldDetails($stateParams.worldId);

});

