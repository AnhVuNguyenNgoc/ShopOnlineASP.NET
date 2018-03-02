(function (app) {

    app.controller('productCategoriesListController', productCategoriesListController);

    productCategoriesListController.$inject = ['$scope', 'apiService'];

    //$scope service của angular
    function productCategoriesListController($scope, apiService) {
        //khai báo
        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;

        //lấy từ pi nên phải thêm vào apiservice sùng $http chứ
        function getProductCategories() {

            apiService.get('/api/productcategory/getall', null, function (result) {
                
                $scope.productCategories = result.data;

            }, function () {
                console.log('Load categories fail !!');
            });
        }

        //Phải gọi một cái để có dữ liệu chứ 
        $scope.getProductCategories();
    }


})(angular.module('shoponline.productCategory'));