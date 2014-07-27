define(['underscore', 'animal'], function(_, Animal) {
    var Result;
    Result = (function() {
        var animals = [
            new Animal('insect', 21),
            new Animal('fish', 1),
            new Animal('mammal', 4),
            new Animal('reptile', 4),
            new Animal('insect', 66),
            new Animal('insect', 8),
            new Animal('insect', 21),
            new Animal('fish', 1),
            new Animal('mammal', 4),
            new Animal('reptile', 4),
            new Animal('insect', 66),
            new Animal('insect', 7),
            new Animal('insect', 6),
            new Animal('fish', 1),
            new Animal('mammal', 4),
            new Animal('reptile', 4),
            new Animal('insect', 66),
            new Animal('insect', 100),
        ];

        var result = _.chain(animals)
            .map(function(a) {
                return a.legs();
            })
            .filter(function(a) { return a === 2 || a === 4 || a === 6 || a === 8 || a === 100; })
            .reduce(function(memo, num) { return memo + num; }, 0)
            .value();
        console.log('Task 5 -------------');
        console.log(result);
        return {
            title: 'Task 5',
            summary: 'By a given array of animals, find the total number of legs (Each animal can have 2, 4, 6, 8 or 100 legs)',
            initial: _.map(animals, function (a) {
                return a.toSimple();
            }),
            result: {
                simple: true,
                value: result
            }
        };
    })();
    return Result;
});