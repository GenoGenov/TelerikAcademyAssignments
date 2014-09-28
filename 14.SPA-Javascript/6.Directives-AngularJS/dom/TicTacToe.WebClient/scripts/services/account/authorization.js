'use strict';

ticTacToe.factory('authorization', ['identity', function(identity) {
    return {
        getAuthorizationHeader: function() {
            return {
                'Authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
            }
        }
    }
}]);