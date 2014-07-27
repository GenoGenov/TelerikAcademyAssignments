define(['underscore', 'student'], function(_, Student) {
    var Result;
    Result = (function() {
        var people = [
            new Student('Ancho', 'Anchev'),
            new Student('Qncho', 'Ganchev'),
            new Student('Boiko', 'Manchov'),
            new Student('Angel', 'Vangelov')
        ];

        var result = _.chain(people)
            .filter(function(p) {
                var r = p.lName().localeCompare(p.fName());
                if (r >= 1) {
                    return true;
                } else {
                    return false;
                }
            })
            .sortBy(function(p) {
                return (p.fName() + p.lName());
            })
            .map(function(p) { return p.fullName(); })
            .value();

        console.log('Task 1 -------------');
        console.log(result);
        return {
            title: 'Task 1',
            summary: 'Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js',
            initial: _.map(people, function(p) {
                            return p.toSimple();
                          }),
            result: {
                simple: true,
                value: result
            }
        };
    })();
    return Result;
});