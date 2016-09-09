worldsModule.controller('AddItemVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams, $uibModalInstance) {
    $scope.name = "";
    $scope.description = "";
    $scope.WorldId = worldId;

    $scope.AddItem = function () {
        var model = {
            WorldId: $scope.WorldId,
            VMEntity: {
                WorldId: $scope.WorldId,
                Name: $scope.name,
                Description: $scope.description

            },
            VMItem: {

            }

        }
        $http.post('/api/ItemsAPI', model).then(function (response) {
            $scope.CreatedItem = response.data;
            $uibModalInstance.close();
        });
    }

    
});

