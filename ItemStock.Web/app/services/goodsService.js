'use strict';
app.factory('goodsService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:1036/';
    var goodsServiceFactory = {};

    var _getGoods = function () {

        return $http.get(serviceBase + 'api/good').then(function (results) {
            return results;
        });
    };

    goodsServiceFactory.getGoods = _getGoods;

    return goodsServiceFactory;

}]);