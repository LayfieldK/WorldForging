//worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams) {
worldsModule.controller('WorldDetailsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, $uibModal, /*worldId,*/ $stateParams) {

    $http({
        method: 'GET',
        url: '/api/WorldsAPI',
        //params: { worldId: worldId }
        params: { worldId: $stateParams.worldId }
    }).then(function (response) {
        $scope.WorldDetails = response.data;
    });

    $scope.showAddCharacterForm = function () {


        $uibModal.open({
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

    }

    

});

