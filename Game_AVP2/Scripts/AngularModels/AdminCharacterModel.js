/// <reference path="../angular/angular.js" />



var AdminCharacterModel = angular
    .module("AdminCharacterModel", ['angular-growl'])
    .constant('Enums', {

        HealthEnums: [
    { id: 1, name: 30 },
    { id: 2, name: 35 },
    { id: 3, name: 40 },
    { id: 4, name: 45 },
    { id: 5, name: 50 },
    { id: 6, name: 55 },
    { id: 7, name: 60 },
    { id: 8, name: 65 },
    { id: 9, name: 70 },
    { id: 10, name: 75 },
    { id: 11, name: 80 },
    { id: 12, name: 85 },
    { id: 13, name: 90 },
    { id: 14, name: 95 }
        ],
        AttributeEnums: [
    { id: 1, name: 7 },
    { id: 2, name: 8 },
    { id: 3, name: 9 },
    { id: 4, name: 10 },
    { id: 5, name: 11 },
    { id: 6, name: 12 },
    { id: 7, name: 13},
    { id: 8, name: 14},
    { id: 9, name: 15 },
    { id: 10, name: 16 }
        ],
        AttributeLowEnums: [
            { id: 1, name: 0 },
            { id: 2, name: 1 },
    { id: 3, name: 2 },
    { id: 4, name: 3 },
    { id: 5, name: 4 },
    { id: 6, name: 5 }
        ],
    })
.controller("StaticCharacterController", function ($scope, $location, Enums, growl, CharacterService, EditCharacterService, DeleteCharacterService, entityService) {
    $scope.detail = {};
    $scope.enums = Enums;
    //$scope.addShow = true;
    getCharacters(true, 0);
    console.log($location.path);
    $scope.init = function (name) {
        $scope.images = name;
    }

    $scope.addCharacter = function (add) {
        entityService.addCharacter(add)
            .then(function (p) {
                getCharacters();
                if (p) {
                    $scope.detail = {};
                    $scope.addShow = false;
                    $scope.detailHide = false,
                    $scope.showSuccess("Character successfully added.");
                }
                else {
                    $scope.showWarning("Please change some information and try again");
                }
            })
    };

    function getCharacters(init, id) {
        CharacterService.getCharacters()
        .success(function (p) {
            $scope.characters = p;
            if (init === true) {
                $scope.detail = {};
                $scope.detail.ImageLink = {};
                $scope.detailBtnHide = true;
            } else if (id > 0) {
                //set detail to character with id
                angular.forEach(p, function (value, key) {
                    if (value.StaticCharacterId === id) {
                        $scope.detail = value;
                    }
                });
            } else {
                $scope.detail = {};
                //hide edit and delete buttons
                $scope.detailBtnHide = true;
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to load character data' + error.message;
            console.log($scope.status);
            return false;
        })
        return true;
    }
    //function getCharacter(Id) {
    //    var dataObj = {
    //        "StaticCharacterId": Id
    //    }
    //    CharacterService.getCharacter(dataObj)
    //    .success(function (character) {
    //        $scope.detail = character;
    //    })
    //    .error(function (error) {
    //        $scope.status = 'Unable to load character' + error.message;
    //        console.log($scope.status);
    //        return false;
    //    })
    //    return true;
    //}
    $scope.reverseListSort = false;
    $scope.sortListColumn = "Name";
    $scope.sortList = function (column) {
        $scope.reverseListSort = ($scope.sortListColumn == column) ? !$scope.reverseListSort : false;
        $scope.sortListColumn = column;
    };
    $scope.getListSortClass = function (column) {
        if ($scope.sortListColumn == column) {
            return $scope.reverseListSort ? 'glyphicon glyphicon-arrow-up' : 'glyphicon glyphicon-arrow-down';
        }
        //to remove previously set arrow class
        return '';
    };
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

    $scope.editCharacter = function (dataObj) {
        EditCharacterService.editCharacter(dataObj)
        .success(function (p) {
            getCharacters(false, dataObj.StaticCharacterId);
            if (p) {
                $scope.editShow = false;
                $scope.detailHide = false;
                $scope.showSuccess("Character info successfully updated.");
            }
            else {
                $scope.editShow = true;
                $scope.showWarning("Something went wrong, please try again");
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to edit character' + error.message;
            console.log($scope.status);
        })
    }
    $scope.delete = function () {
        var id = {
            "Id": $scope.detail.StaticCharacterId
        };
        DeleteCharacterService.deleteCharacter(id)
        .success(function (p) {
            getCharacters(true, 0);
            $scope.editShow = false;
            $scope.showSuccess("Character deleted.");
        })
        .error(function (error) {
            $scope.status = 'Unable to delete character data' + error.message;
            $scope.showWarning("Something went wrong.");
            console.log($scope.status);
        })
    }
    $scope.changeDetail = function (detailObj) {
        changeDetailFunc(detailObj)
        $scope.detailBtnHide = false;
    }
    function changeDetailFunc(detailObj) {
        $scope.detail = detailObj;
    }
    $scope.getEquipment = function getEquipment() {
        entityService.getImages()
        .success(function (imagelist) {
            $scope.images = imagelist;
        })
        .error(function (error) {
            $scope.status = 'Unable to load imagelist' + error.message;
            console.log($scope.status);
            return false;
        })
        entityService.getArmours()
        .success(function (armourlist) {
            $scope.armours = armourlist;
        })
        .error(function (error) {
            $scope.status = 'Unable to load armourlist' + error.message;
            console.log($scope.status);
            return false;
        })
        entityService.getWeapons()
        .success(function (weaponlist) {
            $scope.weapons = weaponlist;
        })
        .error(function (error) {
            $scope.status = 'Unable to load weaponlist' + error.message;
            console.log($scope.status);
            return false;
        })
        return true;
    }
});

AdminCharacterModel.factory('CharacterService', ['$http', '$location', function ($http, $location) {
    var CharacterService = {};
    url = $location.absUrl();

    CharacterService.getCharacters = function () {

        return $http.get(url + '/AdminStaticCharacters/GetStaticCharacters');
    }
    CharacterService.getCharacter = function (id) {
        return $http.get(url + '/AdminStaticCharacters/GetDetail', id);
    }
    return CharacterService;
}])

//factory post edit Character
AdminCharacterModel.factory('EditCharacterService', ['$http', '$location', function ($http, $location) {
    var EditCharacterService = {};
    url = $location.absUrl();
    EditCharacterService.editCharacter = function (dataObj) {

        return $http.post(url + '/AdminStaticCharacters/EditStaticCharacter', dataObj);
    }
    return EditCharacterService;
}])
AdminCharacterModel.factory("entityService",
           ['$http', '$location', function ($http, $location) {
               var entityService = {};
               url = $location.absUrl();
               entityService.addCharacter = function (dataObj) {

                   return $http.post(url + '/AdminStaticCharacters/AddStaticCharacter', dataObj);
               }
               entityService.getImages = function () {
                   return $http.get(url + '/AdminStaticCharacters/GetImages');
               }
               entityService.getArmours = function () {
                   return $http.get(url + '/AdminStaticCharacters/GetArmours');
               }
               entityService.getWeapons = function () {
                   return $http.get(url + '/AdminStaticCharacters/GetWeapons');
               }

               return entityService;
           }]);

//factory post delete item
AdminCharacterModel.factory('DeleteCharacterService', ['$http', '$location', function ($http, $location) {
    var DeleteCharacterService = {};
    url = $location.absUrl();
    DeleteCharacterService.deleteCharacter = function (id) {
        return $http.post(url + '/AdminStaticCharacters/DeleteStaticCharacter', id);
    }
    return DeleteCharacterService;
}])
AdminCharacterModel.config(['$compileProvider', function ($compileProvider) {
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|file|ftp|blob):|data:image\//);
}]);