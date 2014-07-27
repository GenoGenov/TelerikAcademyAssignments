define(['underscore'], function (_) {
    var Result;
    Result = (function () {
        var people = [
            { name: 'pencho', books: 12 },
            { name: 'gencho', books: 33 },
            { name: 'nencho', books: 55 }
        ];

        var result = _.chain(people)
            .max(function(p) { return p.books; })
            .value();
        console.log('Task 6 -------------');
        console.log(result);
        return {
            title: 'Task 6',
            summary: 'By a given collection of books, find the most popular author (the author with the highest number of books)',
            initial: people,
            result: result
        };
    })();
    return Result;
});