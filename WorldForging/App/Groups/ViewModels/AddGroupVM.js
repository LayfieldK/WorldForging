worldsModule.controller('AddGroupVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams, $uibModalInstance) {
    $scope.name = "";
    $scope.description = "";
    $scope.WorldId = worldId;

    $scope.AddGroup = function () {
        var model = {
            WorldId: $scope.WorldId,
            VMEntity: {
                WorldId: $scope.WorldId,
                Name: $scope.name,
                Description: $scope.description

            },
            VMGroup: {

            }

        }
        $http.post('/api/GroupsAPI', model).then(function (response) {
            $scope.CreatedGroup = response.data;
            $uibModalInstance.close();
        });
    }

    
});

