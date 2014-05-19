function Solve(args) {
    var N = parseInt(args[0]);
    args = args.map(Number);
    var answer = 0;
    var max = Number.NEGATIVE_INFINITY;
    var currentSum = 0;
    for (var i = 1; i < args.length; i++) {
        currentSum = args[i];
        for (var j = i + 1; j < args.length; j++) {
            if (args[i] > max) {
                max = args[i];
            }
            if (args[j] > max) {
                max = args[j];
            }
            currentSum += args[j];
            if (currentSum > max) {
                max = currentSum;
            }
        }
    }
    return max;
}

console.log(Solve(['8',
'1',
'6',
'-9',
'4',
'4',
'-2',
'10',
'-1']));
