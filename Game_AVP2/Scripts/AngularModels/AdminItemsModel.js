/// <reference path="angular.min.js" />
/// <reference path="../angular.js" />


var AdminItemsModel = angular
    .module("AdminItemsModel", ['angular-growl', "akFileUploader"])
    .constant('Enums', {
        TypeEnums: [
           { id: 1, name: 'Dagger' },
            { id: 2, name: 'Short Sword' },
            { id: 3, name: 'Long Sword' },
            { id: 4, name: 'Battle Axe' },
            { id: 5, name: 'Spear' },
            { id: 6, name: 'Short Bow' }
        ],

        DamageEnums: [
    { id: 1, name: 3 },
    { id: 2, name: 4 },
    { id: 3, name: 5 },
    { id: 4, name: 6 },
    { id: 5, name: 7 },
    { id: 6, name: 8 },
    { id: 7, name: 9 },
    { id: 8, name: 10 },
    { id: 9, name: 11 },
    { id: 10, name: 12 },
    { id: 11, name: 13 }
        ],

        ExtraDamageEnums: [
    { id: 1, name: 0 },
    { id: 2, name: 1 },
    { id: 3, name: 2 },
    { id: 4, name: 3 },
    { id: 5, name: 4 }
        ],

        RarityEnums: [
    { id: 1, name: 1 },
    { id: 2, name: 2 },
    { id: 3, name: 3 },
    { id: 4, name: 4 },
    { id: 5, name: 5 }
        ],
        ArmourTypeEnums: [
    { id: 1, name: 'Leather armour' },
    { id: 2, name: 'Iron Armour' },
    { id: 3, name: 'Steel Armour' },
    { id: 4, name: 'Dragon Armour' }
        ],

        ProtectionEnums: [
    { id: 1, name: 1 },
    { id: 2, name: 2 },
    { id: 3, name: 3 },
    { id: 4, name: 4 },
    { id: 5, name: 5 }
        ],

        BonusEnums: [
    { id: 1, name: 0 },
    { id: 2, name: 1 },
    { id: 3, name: 2 },
    { id: 4, name: 3 },
    { id: 5, name: 4 }
        ]
    })
.controller("WeaponsController", function ($scope, Enums, growl, ItemsService, EditItemsService, DeleteItemsService, entityService) {
    $scope.weapon = {};
    $scope.enums = Enums;
    //$scope.addShow = true;
    getWeapons(true, 0);
    $scope.init = function (name) {
        $scope.images = name;
    }

    $scope.addWeapon = function (add) {
        entityService.addWeapon(add)
            .then(function (p) {
                getWeapons();
                if (p) {
                    $scope.weapon = {};
                    $scope.addShow = false;
                    $scope.detailHide = false,
                    $scope.showSuccess("Weapon successfully added.");
                }
                else {
                    $scope.showWarning("Please change some information and try again");
                }
            })
        //.error(function (error) {
        //    $scope.status = 'Unable to add weapon' + error.message;
        //    $scope.showWarning("Error: unable to add weapon.");
        //    console.log($scope.status);
        //})
        
    };

    function getWeapons(init, id) {
        ItemsService.getWeapons()
        .success(function (p) {
            $scope.weapons = p;
            if (init === true) {
                $scope.weapon = {};
            } else if (id > 0) {
                //set detail to weapon with id
                angular.forEach(p, function (value, key) {
                    if (value.WeaponId === id) {
                        $scope.weapon = value;
                    }
                });
            } else {
                $scope.weapon = {};
                //hide edit and delete buttons
                $scope.weaponBtnHide = true;
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to load weapons data' + error.message;
            console.log($scope.status);
            return false;
        })
        return true;
    }
    function getImage(Id) {
        var dataObj = {
            "WeaponId": Id
        }
        ItemsService.getWeaponImage(dataObj)
        .success(function (p) {
            $scope.imagelink = p;
        })
        .error(function (error) {
            $scope.status = 'Unable to load weapons image' + error.message;
            console.log($scope.status);
            return false;
        })
        return true;
    }

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

    $scope.editWeapon = function () {
        var dataObj = {
            "WeaponId": $scope.weapon.WeaponId,
            "Name": $scope.weapon.Name,
            "Description": $scope.weapon.Description,
            "Damage": $scope.weapon.Damage,
            "ExtraDamage": $scope.weapon.ExtraDamage,
            "Rarity": $scope.weapon.Rarity,
            "Value": $scope.weapon.Value,
            "WeaponType": $scope.weapon.WeaponType
        };
        EditItemsService.editWeapon(dataObj)
        .success(function (p) {
            getWeapons(false, dataObj.Id);
            if (p) {
                $scope.editShow = false;
                $scope.detailHide = false;
                $scope.showSuccess("Weapon info successfully updated.");
            }
            else {
                $scope.editShow = true;
                $scope.showWarning("Something went wrong, please try again");
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to edit weapon' + error.message;
            console.log($scope.status);
        })
    }
    $scope.deleteWeapon = function () {
        var id = {
            "WeaponId": $scope.weapon.WeaponId
        };
        DeleteItemsService.deleteWeapon(id)
        .success(function (p) {
            getWeapons(true,0);
            $scope.editShow = false;
            $scope.showSuccess("Item deleted.");
        })
        .error(function (error) {
            $scope.status = 'Unable to delete weapon data' + error.message;
            $scope.showWarning("Something went wrong.");
            console.log($scope.status);
        })
    }
    $scope.changeDetail = function (detailObj) {
        changeDetailFunc(detailObj);
        getImage(detailObj.WeaponId);
        $scope.weaponBtnHide = false;
    }
    function changeDetailFunc(detailObj) {
        $scope.weapon = detailObj;
    }
})
.controller("ArmoursController", function ($scope, Enums, growl, ItemsService, EditItemsService, DeleteItemsService, entityService) {
    $scope.armours = {};
    $scope.enums = Enums;
    //$scope.addShow = true;
    getArmours(true, 0);
    function getArmours(init, id) {
        ItemsService.getArmours()
        .success(function (p) {
            $scope.armours = p;
            if (init === true) {
                $scope.armour = p[0];
            } else if (id > 0) {
                angular.forEach(p, function (value, key) {
                    if (value.ArmourId === id) {
                        $scope.armour = value;
                    }
                });
            } else {
                $scope.armour = {};
                //hide edit and delete buttons
                $scope.armourBtnHide = true;
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to load armour data' + error.message;
            console.log($scope.status);
            return false;
        })
        return true;
    }

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

    $scope.editArmour = function () {
        var dataObj = {
            "ArmourId": $scope.armour.ArmourId,
            "Name": $scope.armour.Name,
            "Description": $scope.armour.Description,
            "Defense": $scope.armour.Defense,
            "ExtraDefense": $scope.armour.ExtraDefense,
            "Rarity": $scope.armour.Rarity,
            "Value": $scope.armour.Value,
            "ArmourType": $scope.armour.ArmourType
        };
        EditItemsService.editArmour(dataObj)
        .success(function (p) {
            getArmours(false, dataObj.Id);
            if (p) {
                $scope.editShow = false;
                $scope.detailHide = false;
                $scope.showSuccess("Armour info successfully updated.");
            }
            else {
                $scope.editShow = true;
                $scope.showWarning("Something went wrong, please try again");
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to edit armour' + error.message;
            console.log($scope.status);
        })
    }

    //add person call from $scope
    $scope.addArmour = function () {
        var dataObj = {
            "Name": $scope.Name,
            "Description": $scope.Description,
            "Defense": $scope.Defense,
            "ExtraDefense": $scope.ExtraDefense,
            "Rarity": $scope.Rarity,
            "Value": $scope.Value,
            "ArmourType": $scope.ArmourType
        };
        AddItemsService.addArmour(dataObj)
        .success(function (p) {
            getArmours();
            if (p > 0) {
                $scope.armour = {};
                $scope.addShow = false;
                $scope.showSuccess("Armour successfully added.");
            }
            else {
                $scope.showWarning("Please change some information and try again");
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to add armour' + error.message;
            console.log($scope.status);
        })
    }
    $scope.deleteArmour = function () {
        var id = {
            "ArmourId": $scope.ArmourId
        };
        DeleteItemsService.deleteArmour(id)
        .success(function (p) {
            getArmours(true,0);
            $scope.editShow = false;
            $scope.showSuccess("Item deleted.");
        })
        .error(function (error) {
            $scope.status = 'Unable to delete armour data' + error.message;
            $scope.showWarning("Something went wrong.");
            console.log($scope.status);
        })
    }
    $scope.changeDetail = function (detailObj) {
        changeDetailFunc(detailObj);
        $scope.armourBtnHide = false;
    }
    function changeDetailFunc(detailObj) {
        $scope.armour = detailObj;
    }
});

AdminItemsModel.factory('ItemsService', ['$http', function ($http) {
    var ItemsService = {};

    ItemsService.getWeapons = function () {
        return $http.get('GetWeapons');
    }
    ItemsService.getWeaponImage = function (id) {
        //alert(id);
        return $http.post('GetWeaponImage', id);
    }
    ItemsService.getArmours = function () {
        return $http.get('GetArmours');
    }
    ItemsService.getArmourImage = function (id) {
        //alert(id);
        return $http.post('GetArmourImage', id);
    }
    return ItemsService;
}])

//factory post edit item
AdminItemsModel.factory('EditItemsService', ['$http', function ($http) {
    var EditItemsService = {};
    EditItemsService.editWeapon = function (dataObj) {
        return $http.post('EditWeapon', dataObj);
    }
    EditItemsService.editArmour = function (dataObj) {
        return $http.post('EditArmour', dataObj);
    }
    return EditItemsService;
}])
AdminItemsModel.factory("entityService",
           ["akFileUploaderService", function (akFileUploaderService) {
               var addWeapon = function (data) {
                   console.log(data.Name)
                   console.log(data.error)
                   return akFileUploaderService.saveModel(data, "/Admin/AddWeapon");
               };
               return {
                   addWeapon: addWeapon
               };
               var addArmour = function (data) {
                   console.log(data.Name)
                   console.log(data.error)
                   return akFileUploaderService.saveModel(data, "/Admin/AddArmour");
               };
               return {
                   addArmour: addArmour
               };

           }]);

//factory post delete item
AdminItemsModel.factory('DeleteItemsService', ['$http', function ($http) {
    var DeleteItemsService = {};
    DeleteItemsService.deleteWeapon = function (id) {
        return $http.post('DeleteWeapon', id);
    }
    DeleteItemsService.deleteArmour = function (id) {
        return $http.post('DeleteArmour', id);
    }
    return DeleteItemsService;
}])
AdminItemsModel.config(['$compileProvider', function ($compileProvider) {
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|file|ftp|blob):|data:image\//);
}]);

//(function () {

"use strict"

angular.module("akFileUploader", [])
.factory("akFileUploaderService", ["$q", "$http",
           function ($q, $http) {

               var getModelAsFormData = function (data) {
                   var dataAsFormData = new FormData();
                   angular.forEach(data, function (value, key) {
                       dataAsFormData.append(key, value);
                   });
                   return dataAsFormData;
               };

               var saveModel = function (data, url) {
                   var deferred = $q.defer();
                   $http({
                       url: url,
                       method: "POST",
                       data: getModelAsFormData(data),
                       transformRequest: angular.identity,
                       headers: { 'Content-Type': undefined }
                   }).success(function (result) {
                       deferred.resolve(result);
                   }).error(function (result, status) {
                       deferred.reject(status);
                   });
                   return deferred.promise;
               };

               return {
                   saveModel: saveModel
               }
           }])
.directive("akFileModel", ["$parse",
            function ($parse) {
                return {
                    restrict: "A",
                    link: function (scope, element, attrs) {
                        var model = $parse(attrs.akFileModel);
                        var modelSetter = model.assign;
                        element.bind("change", function () {
                            scope.$apply(function () {
                                modelSetter(scope, element[0].files[0]);
                            });
                        });
                    }
                };
            }]);
//})(window, document);

//add person call from $scope
//$scope.addWeapon = function () {
//    var dataObj = {
//        "Name": $scope.Name,
//        "Description": $scope.Description,
//        "Damage": $scope.Damage,
//        "ExtraDamage": $scope.ExtraDamage,
//        "Rarity": $scope.Rarity,
//        "Value": $scope.Value,
//        "WeaponType": $scope.WeaponType
//    };
//    AddItemsService.addWeapon(dataObj)
//    .success(function (p) {
//        getWeapons();
//        if (p > 0) {
//            $scope.weapon = {};
//            $scope.addShow = false;
//            $scope.showSuccess("Weapon successfully added.");
//        }
//        else {
//            $scope.showWarning("Please change some information and try again");
//        }
//    })
//    .error(function (error) {
//        $scope.status = 'Unable to add weapon' + error.message;
//        console.log($scope.status);
//    })
//}


//factory post add item service
//AdminItemsModel.factory('AddItemsService', ['$http', function ($http) {
//    var AddItemsService = {};
//    AddItemsService.addWeapon = function (dataObj) {
//        return $http.post('AddWeapon', dataObj);
//    }
//    AddItemsService.addArmour = function (dataObj) {
//        return $http.post('AddArmour', dataObj);
//    }
//    return AddItemsService;
//}])