function getPalindromes(input) {
    var words = input.split(' ');
    for (var i = words.length-1; i >= 0; i--) {
        if(words[i]!==words[i].split('').reverse().join('')){
            words.splice(i, 1);
        }
    }
    return words;
}

var text = "abba text mext neven exe almal lalal alalalal";

console.log(getPalindromes(text));