define(['underscore', 'student'], function(_, Student) {
    var Result;
    Result = (function() {
        var people = [
            new Student('Ancho', 'Anchev', 21, [2, 2, 4, 6, 6]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6]),
            new Student('Boiko', 'Manchov', 33, [6, 6, 6, 6, 6]),
            new Student('Angel', 'Vangelov', 20, [3, 3, 3, 3, 3])
        ];

        var result = _.chain(people)
            .max(function(p) {
                return _.reduce(p.marks(), function(memo, num) { return memo + num; }, 0);
            })
            .value();
        console.log('Task 3 -------------');
        console.log(result);
        return {
            title: 'Task 3',
            summary: 'Write a function that by a given array of students finds the student with highest marks',
            initial: _.map(people, function(p) {
                return p.toSimple();
            }),
            result: {
                simple:true,
                value:JSON.stringify(result.toSimple())
            }
    };
    })();
    return Result;
});