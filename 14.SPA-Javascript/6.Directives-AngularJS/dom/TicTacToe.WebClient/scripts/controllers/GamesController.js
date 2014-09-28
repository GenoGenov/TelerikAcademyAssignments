'use strict';

ticTacToe.controller('GamesController', ['$scope', 'notifier', 'games', 'spinner', 'identity', function ($scope, notifier, games, spinner, identity) {

    $scope.identity = identity;

    games.getAllGames().then(function(allGames) {
        $scope.games = allGames;
    });
    $scope.getAllGames = function($event) {
        var l = spinner.create($event.target);
        l.start();
        games.getAllGames().then(function(allGames) {
            l.stop();
            $scope.games = allGames;
        }, function() {
            l.stop();
        });
    };
    
    $scope.join=function() {
        games.joinGame().then(function (id) {
            id = JSON.parse(id);
            var result = $.grep($scope.games, function(e) { return e.Id == id; });
            result[0].SecondPlayer = {};
            
            result[0].SecondPlayer.UserName = identity.getCurrentUser().userName;
        },function(error) {
            notifier.error("Something wrong happened! For More info check network activity(F12)");
        });
    }
}]);