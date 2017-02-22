var app;
(function () {
    //creating module in angular
    app = angular.module("myapplication", ['ngRoute']);//it uses the ngRoute if we implement routing

    //creating controller on angular
    //here $scope object is used to share data between Controller and view.

    app.controller("HomeController", function ($scope) {
        $scope.Message = "Welcome to Angular js buddy!";
        //$scope.Message = "Hi this is Two";
    })
})();