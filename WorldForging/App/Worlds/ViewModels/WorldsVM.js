worldsModule.controller('WorldsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, $uibModal, viewModelHelper) {
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

    $scope.showModal = function () {
        
        
                $uibModal.open({
                    animation: true,
                    ariaLabelledBy: 'modal-title',
                    ariaDescribedBy: 'modal-body',
                    templateUrl: '/App/Worlds/Views/WorldDetailsView.html',
                    controller: 'WorldDetailsVM',
                    controllerAs: '$ctrl',
                    size: 'lg',
                    resolve: {
                        worldId: 29
                    }

                });
            
    }

});