/// <reference path="../../../Assets/admin/libs/angular/angular.js" />


(function (app) {

    //????????????? factory
    app.factory('apiService', apiService);

    //inject nếu không lúc nén code nó không hiểu biến http
    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get : get
        }

        function get(url, params, success, fail) {

            $http.get(url, params).then(function (result) {

                //trả về result chứ . Để bên thằng controller nó lấy result.data
                success(result);

            }, function (error) {
                fail(error);
            });
        }


    }
    //
})(angular.module('shoponline.common')); //Để có ui.route  tùy chỉnh router theo angular js chứ ko chạy theo thằng controller