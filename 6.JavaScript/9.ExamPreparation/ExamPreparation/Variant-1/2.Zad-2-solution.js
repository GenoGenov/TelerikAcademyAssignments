function Solve(params) {
    var N = parseInt(params[0].split(' ')[0]);
    var M = parseInt(params[0].split(' ')[1]);
    var J = parseInt(params[0].split(' ')[2]);
    var R = parseInt(params[1].split(' ')[0]);
    var C = parseInt(params[1].split(' ')[1]);
    var matrix = [];
    var counter = 1;
    for (var i = 0; i < N; i++) {
        matrix[i] = [];
        for (var j = 0; j < M; j++) {
            matrix[i][j] = counter++;
        }
    }
    var index = 2;
    var points = matrix[R][C];
    var jumps = 0;
    var row = R;
    var col = C;
    matrix[R][C] = -1;
    while (index < params.length) {
        row += parseInt(params[index].split(' ')[0]);
        col += parseInt(params[index].split(' ')[1]);
        jumps++;
        if (row < N && col < M) {
            points += matrix[row][col];
            if (matrix[row][col] !== -1) { 
                matrix[row][col] = -1;
            } else {
                return 'caught ' + jumps;
            }
        } else {
            return 'escaped ' + points;
        }
        if (index + 1 >= params.length) {
            index = 2;

        } else {
            index++;
        }
    }
}

console.log(Solve(['500 500 1',
'0 0' ,
'-1 1']));

