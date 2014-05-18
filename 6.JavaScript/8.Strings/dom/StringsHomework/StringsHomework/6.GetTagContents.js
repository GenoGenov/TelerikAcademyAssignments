function getTagContents(input) {
    var result = "";

    var textSize = input.length;
    var index = -1;

    while (index < textSize - 1) {
        index++;

        if (input[index] === "<") {
            index = input.indexOf(">", index);
            result += ' ';
        } else {
            result += input[index];
        }
    }

    return result;
}

var str = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';

console.log(getTagContents(str));