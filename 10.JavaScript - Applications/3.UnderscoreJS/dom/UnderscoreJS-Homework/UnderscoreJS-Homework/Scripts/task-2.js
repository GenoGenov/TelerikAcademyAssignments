define(['underscore', 'student'], function (_, Student) {
    var Result;
    Result = (function () {
        var people = [
            new Student('Ancho', 'Anchev', 21),
            new Student('Qncho', 'Ganchev', 17),
            new Student('Boiko', 'Manchov', 33),
            new Student('Angel', 'Vangelov', 20)
        ];

        var result = _.chain(people)
            .filter(function (p) {
                return p.age() > 18 && p.age() < 24;
            })
            .sortBy(function (p) {
                return (p.fName() + p.lName());
            })
            .map(function (p) { return p.fullName(); })
            .value();
        console.log('Task 2 -------------');
        console.log(result);
        return {
            title: 'Task 2',
            summary:'Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js',
            initial: _.map(people, function (p) {
                return p.toSimple();
            }),
            result: {
                simple: true,
                value: result
            }
        }
    })();
    return Result;
});