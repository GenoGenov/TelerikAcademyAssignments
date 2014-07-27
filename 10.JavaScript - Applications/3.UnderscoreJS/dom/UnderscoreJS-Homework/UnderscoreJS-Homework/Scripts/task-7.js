define(['underscore', 'student'], function(_, Student) {
    var Result;
    Result = (function() {
        var people = [
            new Student('Ancho', 'Anchev', 21, [2, 2, 4, 6, 6]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6]),
            new Student('Boiko', 'Manchov', 33, [6, 6, 6, 6, 6]),
            new Student('Angel', 'Vangelov', 20, [3, 3, 3, 3, 3]),
            new Student('Ancho', 'Anchev', 21, [2, 2, 4, 6, 6]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6]),
            new Student('Boiko', 'Manchov', 33, [6, 6, 6, 6, 6]),
            new Student('Angel', 'Vangelov', 20, [3, 3, 3, 3, 3]),
            new Student('Ancho', 'Anchev', 21, [2, 2, 4, 6, 6]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6]),
            new Student('Boiko', 'Manchov', 33, [6, 6, 6, 6, 6]),
            new Student('Angel', 'Vangelov', 20, [3, 3, 3, 3, 3]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6]),
            new Student('Qncho', 'Ganchev', 17, [4, 4, 4, 5, 6])
        ];

        var result = _.chain(people)
            .map(function(p) { return p.fullName(); })
            .countBy()
            .pairs()
            .max(_.last)
            .head()
            .value();
        console.log('Task 7 -------------');
        console.log(result);
        return {
            title: 'Task 7',
            summary: 'By an array of people find the most common first and last name. Use underscore.',
            initial: _.map(people, function (p) {
                return p.toSimple();
            }),
            result: {
                simple: true,
                value:result
            }
        };
    })();
    return Result;
});