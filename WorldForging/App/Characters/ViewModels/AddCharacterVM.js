﻿worldsModule.controller('AddCharacterVM', function ($scope, worldsService, $http, $q, $routeParams, $window, $location, viewModelHelper, worldId, $stateParams, $uibModalInstance) {
    $scope.name = "";
    $scope.description = "";
    $scope.WorldId = worldId;

    $scope.AddCharacter = function () {
        var model = {
            WorldId: $scope.WorldId,
            VMEntity: {
                WorldId: $scope.WorldId,
                Name: $scope.name,
                Description: $scope.description

            },
            VMCharacter: {

            }

        }
        $http.post('/api/CharactersAPI', model).then(function (response) {
            $scope.CreatedCharacter = response.data;
            $uibModalInstance.close();
        });
    }

    
});

