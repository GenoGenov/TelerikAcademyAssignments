function replaceNonBreakingSpaces(input) {
    var textSize = input.length;
    var result = "";
    for (var i = 0; i < textSize; i++) {
        if (input[i] === " ") {
            result += '&nbsp;';
        }
        else {
            result += input[i];
        }
    }

    return result;
}

var str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

console.log(replaceNonBreakingSpaces(str));