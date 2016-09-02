/// <reference path="../angular/angular.js" />



var GameModel = angular
    .module("GameModel", ['angular-growl', 'ngSanitize'])
    .constant('Enums', {

        HealthEnums: []
    })
.controller("GameController", function ($scope, $location, Enums, growl, entityService) {

    $scope.detail = {};
    $scope.battleShow = true;
    $scope.diceResult =
    'I am test';
    $scope.textHide = true;
    //$scope.addShow = true;
    //console.log($location.path);
    $scope.init = function (gameViewModel) {
        $scope.character = gameViewModel.Character;
    }
    $scope.test = function () {
        alert($scope.diceResult);
        console.log("hej");
    }

    $scope.showWarning = function (text) {
        growl.warning(text, { title: 'Warning!' });
    }
    $scope.showError = function (text) {
        growl.error(text, { title: 'Error!' });
    }
    $scope.showSuccess = function (text) {
        growl.success(text, { title: 'Success!' });
    }
    $scope.showInfo = function () {
        growl.info('This is an info message.', { title: 'Info!' });
    }
    $scope.showAll = function () {
        growl.warning('This is warning message.', { title: 'Warning!' });
        growl.error('This is error message.', { title: 'Error!' });
        growl.success('This is success message.', { title: 'Success!' });
        growl.info('This is an info message.', { title: 'Info!' });
    }
})

GameModel.factory("entityService",
           ['$http', '$location', function ($http, $location) {
               var entityService = {};
               url = $location.absUrl();

               return entityService;
           }]);

GameModel.config(['$compileProvider', function ($compileProvider) {
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|file|ftp|blob):|data:image\//);
}]);