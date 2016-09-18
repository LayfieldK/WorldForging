worldsModule.controller('EntityRelationshipsVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, entityId, $stateParams, $uibModalInstance) {
    $scope.name = "";
    $scope.description = "";
    $scope.EntityId = entityId;

    $scope.LoadEntityRelationships = function (entityId) {
        $http({
            method: 'GET',
            url: '/api/EntitiesAPI',
            params: { entityId: entityId }
        }).then(function (response) {
            $scope.EntityRelationshipsData = response.data;
        });
    }

    $scope.addNewRelationshipRow = function () {
        $scope.EntityRelationshipsData.EntityRelationships.push({});
    };

    $scope.LoadEntityRelationships($scope.EntityId);

});

