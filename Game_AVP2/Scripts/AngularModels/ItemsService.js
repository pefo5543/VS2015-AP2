//(function () {
//    'use strict';

//    angular
//        .module('AdminItemsModel')
//        .factory('ItemsService', factory);

//    factory.$inject = ['$http'];

//    function factory($http) {
//        var ItemsService = {};
        
//        ItemsService.getItems = function () {
//            return $http.get('Admin/GetItems');
//        }
//        return ItemsService;
//    }
//})();


//(function () {
//    'use strict';

//    angular
//        .module('AdminItemsModel')
//        .factory('AddItemsService', factory);

//    factory.$inject = ['$http'];

//    function factory($http) {
//        var AddItemsService = {};
//        AddItemsService.addItem = function (dataObj) {
//            return $http.post('Admin/AddItem', dataObj);
//        }
//        return AddItemsService;
//    }
//})();


//(function () {
//    'use strict';

//    angular
//        .module('AdminItemsModel')
//        .factory('DeleteItemsService', factory);

//    factory.$inject = ['$http'];

//    function factory($http) {
//        var DeleteItemsService = {};
//        DeleteItemsService.deleteItem = function (id) {
//            return $http.post('Admin/DeleteItem', id);
//        }
//        return DeleteItemsService;
//    }
//})();


//var AdminItemsModel = angular.module('AdminItemsModel');
//AdminItemsModel.factory('ItemsService', ['$http', function ($http) {
//    var ItemsService = {};

//    ItemsService.getItems = function () {
//        return $http.get('Admin/GetItems');
//    }
//    return ItemsService;
//}])

//factory post edit item
//AdminItemsModel.factory('EditService', ['$http', function ($http) {
//    var EditService = {};
//    EditService.editDetail = function (dataObj) {
//        return $http.post('Home/Edit', dataObj);
//    }
//    return EditService;
//}])

//factory post add item service
//AdminItemsModel.factory('AddService', ['$http', function ($http) {
//    var AddItemsService = {};
//            AddItemsService.addItem = function (dataObj) {
//                return $http.post('Admin/AddItem', dataObj);
//            }
//            return AddItemsService;
//}])

////factory post delete item
//AdminItemsModel.factory('DeleteService', ['$http', function ($http) {
//    var DeleteItemsService = {};
//            DeleteItemsService.deleteItem = function (id) {
//                return $http.post('Admin/DeleteItem', id);
//            }
//            return DeleteItemsService;
//}])