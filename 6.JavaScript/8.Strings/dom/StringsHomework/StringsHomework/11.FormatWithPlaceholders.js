function stringFormat(format, args) {
    var argindex = 1;
    for (var i in arguments) {
        while (format.indexOf('{' + i + '}') > -1) {
            format = format.replace('{' + i + '}', arguments[argindex]);

        }
        argindex++;
    }

    return format;
}

var str = stringFormat('Hello {0}!', 'Peter');

console.log(str);

var frmt = '{0}, {1}, {0} text {2}';
var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');

console.log(str);