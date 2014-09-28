'use strict';

ticTacToe.controller('SignUpController', ['$scope', '$location', 'auth', 'notifier', 'spinner', function ($scope, $location, auth, notifier, spinner) {
    $scope.signup = function (user, $event) {
        var l = spinner.create($event.target);
        l.start();
        auth.signup(user).then(function () {
            l.stop();
            notifier.success('Registration successful!');
            $location.path('/');
        }, function (error) {
            l.stop();
            var msg = error.error_description || error.message || 'Something wrong happened! See the network response(F12)';
            notifier.error(msg);
        });
    }
}]);