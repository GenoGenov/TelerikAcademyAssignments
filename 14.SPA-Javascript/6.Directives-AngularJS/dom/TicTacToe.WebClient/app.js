var ticTacToe = angular.module("ticTacToe", ['ngRoute', 'ngResource', 'ngCookies'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpController'
            })
            .when('/games', {
                templateUrl: 'views/partials/games.html',
                controller: 'GamesController'
            })
            .when('/partial2', {
                templateUrl: 'views/partials/partial2.html',
                controller: 'MyCtrl2'
            })
            .otherwise({ redirectTo: '/games' });
    }])
    .constant('toastr', toastr)
    .constant('spinnerProvider', Ladda)
    .constant('baseServiceUrl', 'http://localhost:33257');