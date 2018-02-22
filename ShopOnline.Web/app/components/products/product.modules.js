/// <reference path="../Assets/admin/libs/angular/angular.js" />

(function (app) {
    angular.module('shoponline.products', ['shoponline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        });

    }
})();