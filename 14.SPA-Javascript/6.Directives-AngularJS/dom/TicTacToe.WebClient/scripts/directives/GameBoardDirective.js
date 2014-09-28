ticTacToe.directive('gameBoard', function () {
    function inflateBoard(scope, element, attr) {
        var board = attr.gameBoard;
        var $this = $(element);

        for (var i = 0; i < 3; i++) {
            var current = $this.find('tr.' + parseInt(i + 1));
            for (var j = 0; j < 3; j++) {
                var cell = current.find('td.' + parseInt(j + 1));
                cell.html(board[i * 3 + j] != '-' ? board[i * 3 + j] : '');
            }
        }
    }
    return {
        restrict: 'A',
        //scope: { gameBoard: '=' },
        link: function (scope, element, attr) {
            inflateBoard(scope, element, attr);
            attr.$observe('gameBoard', function (newVal, oldVal) {
                attr.gameBoard = newVal;
                inflateBoard(scope, element, attr);
            });
        },
    };
});