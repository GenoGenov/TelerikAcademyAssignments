'use strict';

ticTacToe.controller('LoginController', ['$scope', '$location', 'notifier', 'identity', 'auth','spinner', function($scope, $location, notifier, identity, auth, spinner) {
    $scope.identity = identity;

    $scope.login = function(user, loginForm, $event) {
        if (loginForm.$valid) {
            var l = spinner.create($event.target);
            l.start();
            auth.login(user).then(function (success) {
                l.stop();
                if (success) {
                    notifier.success('Successful login!');
                } else {
                    notifier.error('Username/Password combination is not valid!');
                }
            },function(error) {
                var msg = error.error_description || error.message || 'Something wrong happened! See the network response(F12)';
                notifier.error(msg);
                l.stop();
            });
        }
        else {
            notifier.error('Username and password are required fields!');
        }
    }

    $scope.logout = function() {
        auth.logout().then(function() {
            notifier.success('Successful logout!');
            if ($scope.user) {
                $scope.user.email = '';
                $scope.user.username = '';
                $scope.user.password = '';
            }

            $scope.loginForm.$setPristine();
            $location.path('/');
        });
    }
}])