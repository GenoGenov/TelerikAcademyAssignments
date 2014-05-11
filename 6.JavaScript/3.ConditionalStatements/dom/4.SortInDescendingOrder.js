var a = 9,
    b = 20,
    c = 8;
var biggest, second, third;

if (a > b) {
    if (a > c) {
        biggest = a;
        if (b > c) {
            second = b;
            third = c;
        } else {
            second = c;
            third = b;
        }
    } else {
        biggest = c;
        second = a;
        third = b;
    }
} else if (b > c) {
    biggest = b;
    if (a > c) {
        second = a;
        third = c;
    } else {
        second = c;
        third = a;
    }
} else {
    biggest = c;
    second = b;
    third = a;
}
console.log('Biggest: ' + biggest + ' Second: ' + second + ' Third: ' + third);