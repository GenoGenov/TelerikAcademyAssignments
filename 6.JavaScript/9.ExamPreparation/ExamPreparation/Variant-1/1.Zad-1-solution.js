function Solve(params) {
    var N = parseInt(params[0]);
    var answer = 0;
    var nums = params.map(Number);
    for (var i = 2; i <= N; i++) {
        if (nums[i - 1] > nums[i]) {
            answer++;
        }
    }
    return ++answer;
}

console.log(Solve([9,
1,
8,
8,
7,
6,
5,
7,
7,
6



                  ]));