ticTacToe.factory('games', [
    '$http', '$q', 'baseServiceUrl', 'authorization', function($http, $q, baseServiceUrl, authorication) {
        var gamesApi = baseServiceUrl + '/api/games';
        return {
            getAllGames:function() {
                var deferred = $q.defer();
                $http({ method: 'GET', url: gamesApi + '/all', headers: authorication.getAuthorizationHeader() }).success(function(data) {
                    deferred.resolve(data);
                }).error(function(error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            },
            createGame:function() {
                var deferred = $q.defer();
                $http({ method: 'POST', url: gamesApi + '/create', headers: authorication.getAuthorizationHeader() }).success(function (data) {
                    deferred.resolve(data);
                }).error(function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            },
            joinGame:function() {
                var deferred = $q.defer();
                $http({ method: 'POST', url: gamesApi + '/join', headers: authorication.getAuthorizationHeader() }).success(function (data) {
                    deferred.resolve(data);
                }).error(function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }
        }
    }
]);