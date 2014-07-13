'use strict';
app.controller('goodsController', ['$scope', 'goodsService', function ($scope, goodsService) {

    $scope.goods = [];

    goodsService.getGoods().then(function (results) {

        $scope.goods = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);