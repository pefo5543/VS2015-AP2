/// <reference path="angular.min.js" />


var AdminItemsModel = angular
    .module("AdminItemsModel", ['angular-growl'])
    .constant('Enums', {
        TypeEnums: [
           {id: 1, name: 'Weapon'},
            {id: 2, name: 'Armour'},
            {id: 3, name: 'Misc'}
        ]
    })
.controller("ItemsController", function ($scope, Enums, growl, ItemsService, AddItemsService, DeleteItemsService) {
    $scope.detail = {};
    $scope.enums = Enums;
    getItems(true, 0);
    $scope.init = function (name) {
        $scope.countries = name;
    }
    function getItems() {
        ItemsService.getItems()
        .success(function (p) {
            $scope.weapons = p.WeaponList;
            $scope.armours = p.ArmourList;
            $scope.miscs = p.MiscList;
        })
        .error(function (error) {
            $scope.status = 'Unable to load items data' + error.message;
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

    //$scope.editPeople = function () {
    //    var dataObj = {
    //        "Id": $scope.detail.Id,
    //        "FirstName": $scope.detail.FirstName,
    //        "LastName": $scope.detail.LastName,
    //        "Email": $scope.detail.Email,
    //        "BirthDate": $scope.detail.BirthDate,
    //        "Phone": $scope.detail.Phone,
    //        "CityId": $scope.CityM,
    //        "CountryId": $scope.CountryM
    //    };
    //    EditService.editDetail(dataObj)
    //    .success(function (p) {
    //        getPeople(false, dataObj.Id);
    //        if (p) {
    //            $scope.editShow = false;
    //            $scope.detailHide = false;
    //            $scope.showSuccess("Person info successfully updated.");
    //        }
    //        else {
    //            $scope.editShow = true;
    //            $scope.showWarning("Please update some information and try again");
    //        }
    //    })
    //    .error(function (error) {
    //        $scope.status = 'Unable to edit people data' + error.message;
    //        console.log($scope.status);
    //    })
    //}

    //add person call from $scope
    $scope.addItem = function () {
        var dataObj = {
            "FirstName": $scope.FirstName,
            "LastName": $scope.LastName,
            "GenderId": $scope.Gender,
            "Email": $scope.Email,
            "BirthDate": $scope.BirthDate,
            "Phone": $scope.Phone,
            "CityId": $scope.CityM,
            "CountryId": $scope.CountryM
        };
        AddService.addItem(dataObj)
        .success(function (p) {
            getItems();
            if (p > 0) {
                //$scope.detail = {};
                //$scope.addShow = false;
                $scope.showSuccess("Item successfully added.");
            }
            else {
                $scope.showWarning("Please change some information and try again");
            }
        })
        .error(function (error) {
            $scope.status = 'Unable to add item data' + error.message;
            console.log($scope.status);
        })
    }
    $scope.deleteItem = function () {
        var id = {
            "Id": $scope.Id
        };
        DeleteService.deleteItem(id)
        .success(function (p) {
            getItems();
            //$scope.editShow = false;
            $scope.showSuccess("Item deleted.");
        })
        .error(function (error) {
            $scope.status = 'Unable to delete item data' + error.message;
            $scope.showWarning("Something went wrong.");
            console.log($scope.status);
        })
    }
    //$scope.changeDetail = function (detailObj) {
    //    changeDetailFunc(detailObj);
    //    $scope.personBtnHide = false;
    //}
    //function changeDetailFunc(detailObj) {
    //    $scope.detail = detailObj;
    //    $scope.BirtDateDate = new Date(detailObj.BirthDateString);
    //}
    //$scope.hideCity = function () {
    //    $scope.cityShow = false;
    //}

    //$scope.getCities = function (countryId) {
    //    CityService.getCities(countryId)
    //    .success(function (c) {
    //        $scope.cities = c;
    //        //show city select in list
    //        $scope.cityShow = true;
    //    })
    //    .error(function (error) {
    //        $scope.status = 'Unable to get cities' + error.message;
    //        console.log($scope.status);
    //        alert(error.message);
    //    })
    //}
});

AdminItemsModel.factory('ItemsService', ['$http', function ($http) {
    var ItemsService = {};

    ItemsService.getItems = function () {
        return $http.get('GetItems');
    }
    return ItemsService;
}])

//factory post edit item
//AdminItemsModel.factory('EditService', ['$http', function ($http) {
//    var EditService = {};
//    EditService.editDetail = function (dataObj) {
//        return $http.post('Home/Edit', dataObj);
//    }
//    return EditService;
//}])

//factory post add item service
AdminItemsModel.factory('AddItemsService', ['$http', function ($http) {
    var AddItemsService = {};
    AddItemsService.addItem = function (dataObj) {
        return $http.post('Admin/AddItem', dataObj);
    }
    return AddItemsService;
}])

//factory post delete item
AdminItemsModel.factory('DeleteItemsService', ['$http', function ($http) {
    var DeleteItemsService = {};
    DeleteItemsService.deleteItem = function (id) {
        return $http.post('Admin/DeleteItem', id);
    }
    return DeleteItemsService;
}])