var app = angular.module('Dropdown', ['angularjs-dropdown-multiselect']);
app.controller('multiselectdropdown', ['$scope', '$http', function ($scope, $http) {
    //define object 
    $scope.SkatingRolesSelected = [];
    $scope.SkatingRoles = [];
    $scope.dropdownSetting = {
        scrollable: true,
        scrollableHeight: '200px'
    }
    //fetch data from database for show in multiselect dropdown
    $http.get('/profile/getskatingroles').then(function (data) {
        angular.forEach(data.data, function (value, index) {
            $scope.SkatingRoles.push({ id: value.SkatingId, label: value.SkatingRole });
        });
    })
    //post or submit selected items from multiselect dropdown to server
    $scope.SubmittedSkatingRoles = [];
    $scope.SubmitData = function () {
        var SkatingIds = [];
        angular.forEach($scope.SkatingRolesSelected, function (value, index) {
            SkatingIds.push(value.id);
        });

        var data = {
            skatingIds: skatingIds
        };

        $http({
            method: "POST",
            url: "/profile/savedata",
            data: JSON.stringify(data)
        }).then(function (data) {
            $scope.SubmittedSkatingRoles = data.data;
        }, function (error) {
            alert('Error');
        })
    }
}])