/// <reference path="../Assets/admin/libs/angular/angular.js" />

(function () {

    //Khởi tạo config module shoponline.productCategory
    angular.module('shoponline.productCategory', ['shoponline.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/productCategorytListView.html",
            controller: "productCategoryListController"
        }).state('add_product_categories', {
            url: "/add_product_categories",
            templateUrl: "/app/components/product_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        })
            //Thêm tham số mới update dc nha 
            .state('update_product_categories', {
            url: "/update_product_categories/:id",
            templateUrl: "/app/components/product_categories/productCategoryUpdateView.html",
            controller: "productCategoryUpdateController"
        });

    }
})();