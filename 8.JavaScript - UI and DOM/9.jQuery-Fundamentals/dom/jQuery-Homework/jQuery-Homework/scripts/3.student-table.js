window.onload = function () {
    var students = [{
            fName: 'qnko',
            lName: 'qnkov',
            grade: 3,
        }, {
            fName: 'bqnko',
            lName: 'bqnkov',
            grade: 4,
        }, {
            fName: 'tqnko',
            lName: 'tqnkov',
            grade: 5,
        }, {
            fName: 'mqnko',
            lName: 'mqnkov',
            grade: 6,
        }
    ];
    var container = $('#container');
    var table = $('<table>');
    var headerRow = $('<thead>').append($('<tr>').append($('<th>').html('First Name')).append($('<th>').html('Last Name')).append($('<th>').html('Grade')));
    table.append(headerRow);
    container.append(table);
    var row = $('<tr>').append($('<td>')).append($('<td>')).append($('<td>'));
    for (var i = 0; i < students.length; i++) {
        var first = row.find('td').first();
        var student = students[i];
        for (var j in student) {
            first.html(student[j]);
            console.log(row.html());
            first = first.next();
        }
        table.append(row.clone());
    }
}