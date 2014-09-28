ticTacToe.factory('play', [
    '$http', '$q', 'baseServiceUrl', 'authorization', function ($http, $q, baseServiceUrl, authorication) {
        var gamesApi = baseServiceUrl + '/api/games';
        return {
            request: function (playRequest) {
                var deferred = $q.defer();
                $http({ method: 'POST', url: gamesApi + '/play', data:playRequest , headers: authorication.getAuthorizationHeader() }).success(function (data) {
                    deferred.resolve(data);
                }).error(function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }
            
        }
    }
]);