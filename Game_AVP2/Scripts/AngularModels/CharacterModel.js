﻿/// <reference path="../angular/angular.js" />



var CharacterModel = angular
    .module("CharacterModel", ['angular-growl'])
.controller("CharacterController", function ($scope, $location, growl, CharacterService) {
    $scope.detail = {};
    //$scope.enums = Enums;
    //$scope.detailShow = true;
    //getCharacters(true, 0);
    $scope.init = function (model) {
        $scope.characters = model;
        $scope.detailBtnHide = true;
    }
    $scope.selectCharacter = function (detailId) {
        CharacterService.postCharacter(detailId)
        .success(function (p) {
            if (p) {
                url = $location.absUrl();
                $window.location.href = url;
            }
            else {
                $scope.detailShow = false;
                $scope.showWarning("Something went wrong, please try again");
            }
        })
        .error(function (error) {
            $scope.status = 'Something went wrong' + error.message;
            console.log($scope.status);
        })
    }
    $scope.changeDetail = function (detail) {
        //CharacterService.getCharacter(detail)
        //.success(function (detail) {
        //    changeDetailFunc(detail)
        //    $scope.detailShow = true;
        //    $scope.detailBtnHide = false;
        //})
        //.error(function (error) {
        //    $scope.status = 'Something went wrong' + error.message;
        //    console.log($scope.status);
        //})

        changeDetailFunc(detail)
        $scope.detailShow = true;
        $scope.detailBtnHide = false;
    }
    function changeDetailFunc(detailObj) {
        $scope.detail = detailObj;
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
});

CharacterModel.factory('CharacterService', ['$http', '$location', function ($http, $location) {
    var CharacterService = {};
    url = $location.absUrl();

    CharacterService.postCharacter = function (staticId) {
        var data = { 'StaticCharacterId': staticId };
        return $http.post('SetCharacter', data);
    }
    //CharacterService.getCharacter = function (StaticCharacterId) {
    //    var data = { 'StaticCharacterId': StaticCharacterId };
    //    return $http.post('GetCharacter', data);
    //}
    return CharacterService;
}])

//factory post edit Character
//AdminCharacterModel.factory('EditCharacterService', ['$http', '$location', function ($http, $location) {
//    var EditCharacterService = {};
//    url = $location.absUrl();
//    EditCharacterService.editCharacter = function (dataObj) {

//        return $http.post(url + '/AdminStaticCharacters/EditStaticCharacter', dataObj);
//    }
//    return EditCharacterService;
//}])
//AdminCharacterModel.factory("entityService",
//           ['$http', '$location', function ($http, $location) {
//               var entityService = {};
//               url = $location.absUrl();
//               entityService.addCharacter = function (dataObj) {

//                   return $http.post(url + '/AdminStaticCharacters/AddStaticCharacter', dataObj);
//               }
//               entityService.getImages = function () {
//                   return $http.get(url + '/AdminStaticCharacters/GetImages');
//               }
//               entityService.getArmours = function () {
//                   return $http.get(url + '/AdminStaticCharacters/GetArmours');
//               }
//               entityService.getWeapons = function () {
//                   return $http.get(url + '/AdminStaticCharacters/GetWeapons');
//               }

//               return entityService;
//}]);

//factory post delete item
//AdminCharacterModel.factory('DeleteCharacterService', ['$http', '$location', function ($http, $location) {
//    var DeleteCharacterService = {};
//    url = $location.absUrl();
//    DeleteCharacterService.deleteCharacter = function (id) {
//        return $http.post(url + '/AdminStaticCharacters/DeleteStaticCharacter', id);
//    }
//    return DeleteCharacterService;
//}])
//AdminCharacterModel.config(['$compileProvider', function ($compileProvider) {
//    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|file|ftp|blob):|data:image\//);
//}]);