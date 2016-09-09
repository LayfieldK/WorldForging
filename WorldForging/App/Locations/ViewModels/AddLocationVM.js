worldsModule.controller('AddLocationVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams, $uibModalInstance) {
    $scope.name = "";
    $scope.description = "";
    $scope.WorldId = worldId;

    $scope.AddLocation = function () {
        var model = {
            WorldId: $scope.WorldId,
            VMEntity: {
                WorldId: $scope.WorldId,
                Name: $scope.name,
                Description: $scope.description

            },
            VMLocation: {

            }

        }
        $http.post('/api/LocationssAPI', model).then(function (response) {
            $scope.CreatedLocation = response.data;
            $uibModalInstance.close();
        });
    }

    
});

