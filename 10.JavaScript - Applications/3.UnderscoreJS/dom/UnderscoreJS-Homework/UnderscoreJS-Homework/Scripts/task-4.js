define(['underscore', 'animal'], function (_, Animal) {
    var Result;
    Result = (function () {
        var animals = [
            new Animal('insect', 21),
            new Animal('fish', 0),
            new Animal('mammal', 4),
            new Animal('reptile', 4),
            new Animal('insect', 66),
            new Animal('insect', 7)
        ];

        var result = _.chain(animals)
            .groupBy(function (a) { return a.species(); })
            .each(function(animals, index, list) {
                list[index] = _.sortBy(animals, function(a) {
                    return a.legs();
                }
                );
            })
            .value();
        console.log('Task 4 -------------');
        console.log(result);
        return {
            title: 'Task 4',
            summary: 'Write a function that by a given array of animals, groups them by species and sorts them by number of legs',
            initial: _.map(animals, function(a) {
                return a.toSimple();
            }),
            result: {
                simple: true,
                value: JSON.stringify(_.each(result,function(animals, index, list) {
                    list[index] = _.map(animals, function(a) { return a.toSimple(); });
                }))
            }
    };
    })();
    return Result;
});