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
    

    

    $scope.showEntityRelationships = function (entityId) {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/App/Entities/Views/EntityRelationshipsView.html',
            controller: 'EntityRelationshipsVM',
            controllerAs: '$ctrl',
            size: 'lg',
            resolve: {
                entityId: function () {
                    return entityId;
                }
            }
        });
        modalInstance.result.then(function () {
            $scope.LoadEntityRelationships(entityId);
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

    $scope.showAddGroupForm = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/App/Groups/Views/AddGroupView.html',
            controller: 'AddGroupVM',
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

    $scope.showAddLocationForm = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/App/Locations/Views/AddLocationView.html',
            controller: 'AddLocationVM',
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

    $scope.showAddWorldEventForm = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/App/WorldEvents/Views/AddWorldEventView.html',
            controller: 'AddWorldEventVM',
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

    $scope.showAddItemForm = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/App/Items/Views/AddItemView.html',
            controller: 'AddItemVM',
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

