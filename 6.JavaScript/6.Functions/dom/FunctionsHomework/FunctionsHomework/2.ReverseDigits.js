var num = 3568338;

function reverseDigits(number) {
    number = parseInt(number) || -1;
    var str = number.toString();
    return parseInt(str.split('').reverse().join(''));
}

console.log(reverseDigits(num));