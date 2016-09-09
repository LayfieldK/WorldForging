worldsModule.controller('AddWorldEventVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams, $uibModalInstance) {
    $scope.name = "";
    $scope.description = "";
    $scope.WorldId = worldId;

    $scope.AddWorldEvent = function () {
        var model = {
            WorldId: $scope.WorldId,
            VMEntity: {
                WorldId: $scope.WorldId,
                Name: $scope.name,
                Description: $scope.description

            },
            VMWorldEvent: {

            }

        }
        $http.post('/api/WorldEventsAPI', model).then(function (response) {
            $scope.CreatedWorldEvent = response.data;
            $uibModalInstance.close();
        });
    }

    
});

