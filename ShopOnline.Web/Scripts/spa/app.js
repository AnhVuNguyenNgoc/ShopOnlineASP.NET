/// <reference path="../plugins/angular.js" />

var AnhVu = angular.module("AnhVu", []);

AnhVu.controller("MyController", MyController);
AnhVu.controller("HerController", HerController);
AnhVu.controller("HisController", HisController);

AnhVu.service("Validator", Validator);
//MyController.$inject = ['$scope'];

//declare controller


//$rootScope này là biến của angular nha . không phải tự bịa . 
// -> Ghi đúng chính tả nó mới hiểu

function MyController($scope, Validator) {

    $scope.Number = 10;

    //listen event
    $scope.KiemTra = function () {
        $scope.message = Validator.KiemTra($scope.Number);
    }
   
  
}

//-------------SERVICE---------------------
function Validator($window) {

    return {
        //khai báo function cho Service
        KiemTra: KiemTra //nhiều hàm thì , ,  ,
    }

    function KiemTra(input) {
        if (input % 2 == 0) {
            //thay vì true false thì có thể xuất ra windown
            return 'số chẵn';
        } else {
            return 'số lẻ';
        }
    }

}


function HerController($scope) {

    $scope.message = "uncensored";
}
function HisController($scope) {

    $scope.message = "His Uncensored";
}

