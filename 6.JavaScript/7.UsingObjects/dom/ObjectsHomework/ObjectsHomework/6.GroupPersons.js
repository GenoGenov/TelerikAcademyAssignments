var persons = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Chicho', lastname: 'Pitko', age: 31 },
    { firstname: 'Micho', lastname: 'Mitko', age: 31 },
    { firstname: 'Fanko', lastname: 'Totev', age: 31 },
    { firstname: 'Chicho', lastname: 'Mitko', age: 81 },
    { firstname: 'Pencho', lastname: 'Levov', age: 100 },
    { firstname: 'Hristo', lastname: 'Batev', age: 63 },
    { firstname: 'Krisko', lastname: 'Baby', age: 100 },
    { firstname: 'Kilata', lastname: 'Maika', age: 100 },
];

function group(array, criterion) {
    var result = [];

    for (var i = persons.length - 1; i >= 0; i--) {
        for (var prop in persons[i]) {
            if (prop === criterion) {
                if (!result[persons[i][prop]]) {
                    result[persons[i][prop]] = [];
                }
                result[persons[i][prop]].push(persons[i]);
            }
        }
    }

    for (var crit in result) {
        console.log(crit + ':');
        for (var i in result[crit]) {
            console.log(result[crit][i].firstname + ' ' + result[crit][i].lastname);
        }
        console.log();
    }

    return result;
}

//var groupedByAge = group(persons, 'age');
var groupedByFname = group(persons, 'firstname');