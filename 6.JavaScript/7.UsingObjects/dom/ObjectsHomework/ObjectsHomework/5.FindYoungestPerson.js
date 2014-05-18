var persons = [
    { firstname : 'Gosho', lastname: 'Petrov', age: 32 }, 
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname : 'Chicho', lastname: 'Mitko', age: 31}
];

var youngest = Number.POSITIVE_INFINITY;
var youngestPersonIndex = -1;

for (var i = persons.length - 1; i >= 0; i--) {
    if (persons[i].age < youngest) {
        youngest = persons[i].age;
        youngestPersonIndex = i;
    }
}

console.log(persons[youngestPersonIndex].firstname + ' ' + persons[youngestPersonIndex].lastname);