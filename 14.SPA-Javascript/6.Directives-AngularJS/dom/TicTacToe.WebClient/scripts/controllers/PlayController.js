ticTacToe.controller('PlayController', [
    '$scope', 'play', 'identity', 'notifier', function ($scope, play, identity, notifier) {
        $scope.play = function (playRequest, game) {
            var usrName = identity.getCurrentUser().userName;
            var gameSymbol = game.FirstPlayer.UserName == usrName ? 'X' : 'O';
            
            play.request(playRequest).then(function () {
                game.Board = game.Board.substr(0, (playRequest.row - 1) * 3 + playRequest.col - 1) + gameSymbol + game.Board.substr((playRequest.row - 1) * 3 + playRequest.col);
                //game.Board[playRequest.row * 3 + playRequest.col] = gameSymbol;
                notifier.success('You played on row:' + playRequest.row + ' and col:' + playRequest.col);
            }, function (error) {
                var msg = error.error_description || error.message || error.Message || 'Something wrong happened! See the network response(F12)';
                notifier.error(msg);
            });
        }

    }
]);