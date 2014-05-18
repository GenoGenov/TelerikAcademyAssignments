function generateList(objects, template) {
    template = template.trim();
    var result = '<ul>';
    for (var i = 0; i < objects.length; i++) {
        var currentLine = '<li>';
        var currentEl = template;
        for (var prop in objects[i]) {
            if (template.indexOf(prop) > -1) {
                while (currentEl.indexOf(prop) > -1) {
                    currentEl = currentEl.replace(prop, objects[i][prop]);
                }
            }
        }
        currentLine += currentEl + '</li>';
        result+=currentLine;
    }
    result += '</ul>';
    return result;
}

var people = [{ name: 'Peter', age: 14 }, { name: 'Gosho', age: 17 }];
var tmpl = document.getElementById('list-item').innerHTML;
var peopleList = generateList(people, tmpl);

document.getElementById('list-item').innerHTML = peopleList;
console.log(peopleList);