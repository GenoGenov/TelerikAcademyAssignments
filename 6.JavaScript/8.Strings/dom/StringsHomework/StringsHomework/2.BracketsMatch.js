function isMatch(expression) {
    var len = expression.length;
    var level = 0;

    for (var i = 0; i < len; i++) {
        if (expression[i] === ')') {
            if (level === 0) {
                return false;
            }
            level--;
        }
        else if (expression[i] === '(') {
            level++;
        }
    }

    return level === 0;
}

var correct = '((a+b)/5-d)';
var incorrect = ')(a+b))';

console.log(isMatch(correct));
console.log(isMatch(incorrect));