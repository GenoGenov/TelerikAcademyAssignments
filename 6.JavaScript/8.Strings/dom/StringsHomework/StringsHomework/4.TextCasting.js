function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

String.prototype.toMixedCase = function () {
    var casing;
    var size = this.length;
    var builder = this.split('');

    for (var i = 0; i < size; i++) {
        casing = getRandomInt(0, 1);
        if (casing === 0) {
            builder[i] = builder[i].toLowerCase();
        } else {
            builder[i] = builder[i].toUpperCase();
        }
    }

    return builder.join('');
}

function replaceCasing(str) {
    var upperCasePattern = new RegExp('<upcase>([^<>]+)<\/upcase>', 'gi');
    var lowerCasePattern = new RegExp('<lowcase>([^<>]+)<\/lowcase>', 'gi');
    var mixedCasePattern = new RegExp('<mixcase>([^<>]+)<\/mixcase>', 'gi');
    while (upperCasePattern.test(str) || lowerCasePattern.test(str) || mixedCasePattern.test(str)) {
        str = str.replace(upperCasePattern, function (match, capture) {
            return capture.toUpperCase();
        });
        str = str.replace(lowerCasePattern, function (match, capture) {
            return capture.toLowerCase();
        });
        str = str.replace(mixedCasePattern, function (match, capture) {
            return capture.toMixedCase();
        });
    }
    return str;
}


var str = "We are <upcase><mixcase>living</mixcase></upcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
str = replaceCasing(str);
console.log(str);

