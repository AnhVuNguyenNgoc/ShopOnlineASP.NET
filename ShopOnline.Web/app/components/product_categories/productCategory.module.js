/// <reference path="../Assets/admin/libs/angular/angular.js" />

(function (app) {

    //Khởi tạo config module shoponline.productCategory
    angular.module('shoponline.productCategory', ['shoponline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/productCategorytListView.html",
            controller: "productCategoriesListController"
        });

    }
})();