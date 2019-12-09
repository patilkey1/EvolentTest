/// <reference path="components/Contact/views/Contact_Table.html" />

'use strict';

var $urlRouterProviderRef = null;
var $stateProviderRef = null;
//'ngAnimate', 'ngSanitize', 
var app = angular.module('app', ['ui.router'])


app.config(function ($stateProvider, $urlRouterProvider) {

    //$urlRouterProvider.otherwise('/party');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        //.state('party', {
        //    url: '/party',
        //    templateUrl: 'Contact_Table.html'
        //})

    //.state('party', {
    //    url: '/party',
    //    templateUrl: '../app/components/Contact/views/Contact_Table.html'
    //})

    .state('party', {
        url: '/party',
        templateUrl: 'TestPage2.html'
    })

    
        // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
        //.state('about', {
        //    // we'll get to this in a bit       
        //});
});

// directive for Loader
app.directive('loading', function () {
    return {
        restrict: 'E',
        replace: true,
        template: '<div style="background-color: #2b323a;position: absolute;top:0;bottom: 0;left: 0;right: 0;margin: auto;z-index: 20;opacity: 0.1;"><div class="loading" style="position: absolute;left: 40%;top: 30%;z-index: 2;"><img src="../Content/Loader_Circle.gif" width="100%" height="100%"></div></div>',
        link: function (scope, element, attr) {
            scope.$watch('loading', function (val) {
                if (val)
                    scope.loadingStatus = 'true';
                else
                    scope.loadingStatus = 'false';
            });
        }
    }
})



