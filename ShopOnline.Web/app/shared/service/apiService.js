/// <reference path="../../../Assets/admin/libs/angular/angular.js" />


(function (app) {

    //????????????? factory
    app.factory('apiService', apiService);

    //inject nếu không lúc nén code nó không hiểu biến http
    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {

        return {
            get: get,
            post: post,
            put: put
        }


        function get(url, params, success, fail) {

            $http.get(url, params).then(function (result) {

                //trả về result chứ . Để bên thằng controller nó lấy result.data
                success(result);

            }, function (error) {
                fail(error);
            });
        }

        function post(url, data, success, fail) {

            $http.post(url, data).then(function (result) {

                //trả về result chứ . Để bên thằng controller nó lấy result.data
                success(result);

            }, function (error) {
                console.log(error.status);
                //status ở đây nó không chiu '401' string 401 ah 
                if (error.status === 401) {
                    notification.displayWarning("Bạn chưa đăng nhập không được Lưu dữ liệu ");
                } else if (fail != null) {
                    fail(error);
                }

               
            });
        }

        function put(url, data, success, fail) {

            $http.put(url, data).then(function (result) {

                //trả về result chứ . Để bên thằng controller nó lấy result.data
                success(result);

            }, function (error) {
                console.log(error.status);
                //status ở đây nó không chiu '401' string 401 ah 
                if (error.status === 401) {
                    notification.displayWarning("Bạn chưa đăng nhập không được Lưu dữ liệu ");
                } else if (fail != null) {
                    fail(error);
                }
            });
        }

    }
    //
})(angular.module('shoponline.common')); //Để có ui.route  tùy chỉnh router theo angular js chứ ko chạy theo thằng controller