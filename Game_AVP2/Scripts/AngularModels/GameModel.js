/// <reference path="../angular/angular.js" />



var GameModel = angular
    .module("GameModel", ['angular-growl', 'ngSanitize'])
    .constant('Enums', {

        HealthEnums: []
    })
.controller("GameController", function ($scope, $location, Enums, growl, entityService) {
    //var keepgoing = true;
    $scope.currentStory = {};
    $scope.battleCount = 1;
    $scope.roundCount = 1;

    $scope.init = function (gameViewModel) {
        $scope.textHide = false;
        $scope.battleShow = false;
        //angular.fromJson()
        $scope.character = gameViewModel.Character;
        $scope.episode = gameViewModel.Episode;
        //find first story
        for (var i = 0, len = gameViewModel.Episode.Stories.length; i < len; i++) {
            if (gameViewModel.Episode.Stories[i].IsFirst === true) {
                //$scope.currentStory = angular.fromJson(gameViewModel.Episode.Stories[i]);
                $scope.currentStory = gameViewModel.Episode.Stories[i];
                break;
            }
            console.log('Loop will continue.');
        }
    }
    //gets here from textwindow, next text, or battle:
    $scope.textContinue = function () {
        if ($scope.currentStory.IsBattle === true) {
            $scope.battleShow = true;
            $scope.textHide = true;

            //get generated monster from server:
            entityService.getMonster($scope.episode.MonsterRarities)
            .success(function (p) {
                $scope.monster = p;
            })
        .error(function (error) {
            $scope.status = 'Unable to get monster' + error.message;
            console.log($scope.status);
        })

        }
    }





    $scope.diceResultFunc = function (diceResult) {
        //alert(diceResult);
        $scope.resultPlayerDice = diceResult;
        //$scope.diceHide = true;
        //un-disable roll dice button
        $scope.myButton = false;
        $scope.diceRollMonsterMsg = "Test monster rolls 4";
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
    //alert user when trying to browse
    function MyCtrl1($scope) {
        $scope.$on('$locationChangeStart', function (event) {
            var answer = confirm("Are you sure you want to leave this page?")
            if (!answer) {
                event.preventDefault();
            }
        });
    }
})

GameModel.factory("entityService",
           ['$http', '$location', function ($http, $location) {
               var entityService = {};
               url = $location.absUrl();
               entityService.getMonster = function (list) {
                   return $http.post('GetMonster', list);
                                  }
                   //               entityService.getArmours = function () {
                   //                   return $http.get(url + '/AdminStaticCharacters/GetArmours');
                   //               }

               return entityService;
           }]);

GameModel.config(['$compileProvider', function ($compileProvider) {
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|file|ftp|blob):|data:image\//);
}]);