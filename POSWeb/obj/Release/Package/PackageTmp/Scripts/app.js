angular.module('ui.bootstrap.demo', ['ngAnimate', 'ui.bootstrap']);
angular.module('ui.bootstrap.demo').controller('DatepickerPopupDemoCtrl', function ($scope) {

    $scope.dateOptions = {
        //dateDisabled: disabled,   disables the popup
        formatYear: 'yy',
        maxDate: new Date(2020, 5, 22),
        minDate: new Date(),
        startingDay: 1,
    };
    /*// Disable weekend selection
    function disabled(data) {
        var date = data.date,
          mode = data.mode;
        return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
    }*/
    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];
    $scope.open = function () {
        $scope.popup1.opened = true;
    };
    $scope.popup1 = {
        opened: false
    };
    /*we can set date
    $scope.setDate = function (year, month, day) {
        $scope.dtpicker = new Date(year, month, day);
    };*/
});
var app = angular.module('MyForm', ['ui.bootstrap', 'ngResource']);
app.controller('myCtrl', function ($scope) {
    $scope.predicate = 'name';
    $scope.reverse = true;
    $scope.currentPage = 1;
    $scope.order = function (predicate) {
        $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
        $scope.predicate = predicate;
    };
    $scope.students = [
      { name: 'Kevin', age: 25, gender: 'boy' },
      { name: 'John', age: 30, gender: 'girl' },
      { name: 'Laura', age: 28, gender: 'girl' },
      { name: 'Joy', age: 15, gender: 'girl' },
      { name: 'Mary', age: 28, gender: 'girl' },
      { name: 'Peter', age: 95, gender: 'boy' },
      { name: 'Bob', age: 50, gender: 'boy' },
      { name: 'Erika', age: 27, gender: 'girl' },
      { name: 'Patrick', age: 40, gender: 'boy' },
      { name: 'Tery', age: 60, gender: 'girl' }
    ];
    $scope.totalItems = $scope.students.length;
    $scope.numPerPage = 5;
    $scope.paginate = function (value) {
        var begin, end, index;
        begin = ($scope.currentPage - 1) * $scope.numPerPage;
        end = begin + $scope.numPerPage;
        index = $scope.students.indexOf(value);
        return (begin <= index && index < end);
    };
});

angular.module("CombineModule", ["ui.bootstrap.demo", "MyForm"]);