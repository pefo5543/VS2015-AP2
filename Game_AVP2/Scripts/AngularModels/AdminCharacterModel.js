/// <reference path="../angular/angular.js" />



var AdminCharacterModel = angular
    .module("AdminCharacterModel", ['angular-growl', "akFileUploader"])
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

        DefenseEnums: [
    { id: 1, name: 1 },
    { id: 2, name: 2 },
    { id: 3, name: 3 },
    { id: 4, name: 4 },
    { id: 5, name: 5 }
        ],

        ExtraDefenseEnums: [
    { id: 1, name: 0 },
    { id: 2, name: 1 },
    { id: 3, name: 2 },
    { id: 4, name: 3 },
    { id: 5, name: 4 }
        ]
    })
.controller("StaticCharacterController", function ($scope, $location, Enums, growl, ItemsService, EditItemsService, DeleteItemsService, entityService) {

});