function Solve(params, funcs) {
    function isOperator(symbol) {
        switch (symbol) {
            case '+':
            case '-':
            case '*':
            case '/':
                return true;
            default:
                return false;
        }
    }

    var answer = 0;
    var line = 0;
    var level = 0;
    var defining = false;
    var functions = arguments[1] || {};
    var lineResult = 0;
    var errMsg = 'Division by zero! At Line:';
    while (line < params.length) {
        var currentLine = params[line];
        for (var i = 0; i < currentLine.length; i++) {
            if (currentLine[i] === '(') {
                level++;
                if (level > 1) {
                    var inner = Solve([currentLine.substring(i, currentLine.indexOf(')', i + 1) + 1)], functions).toString();
                    currentLine = currentLine.replace(currentLine.substring(i, currentLine.indexOf(')'), i + 1), inner);
                    if (inner.indexOf(errMsg) > -1) {
                        return errMsg + (line + 1);
                    }
                    level--;
                    i--;
                    continue;
                }
            }
            if (defining) {
                var funcName = currentLine.substring(i, currentLine.length).trim();
                if (funcName.indexOf('(') > -1) {
                    currentLine = currentLine.
                    replace(currentLine.substring(currentLine.indexOf('(', currentLine.indexOf(funcName)), currentLine.indexOf(')', i + 1)),
                            Solve([currentLine.substring(currentLine.indexOf('(', 2), currentLine.indexOf(')', i + 1) + 1)], functions));
                    if (currentLine.indexOf(errMsg) > -1) {
                        return errMsg + (line + 1);
                    }
                    i--;
                    continue;
                }
                if (funcName.indexOf(' ') > -1) {
                    funcName = funcName.substring(0, funcName.indexOf(' '));
                } else {
                    funcName = funcName.substring(0, funcName.indexOf(')'));
                }
                var funcValue = currentLine.substring(currentLine.indexOf(funcName) + funcName.length, currentLine.length).trim();
                if (funcValue.indexOf(' ') > -1) {
                    funcValue = parseInt(funcValue.substring(0, funcValue.indexOf(' ') - 1));
                } else {
                    funcValue = parseInt(funcValue.substring(0, funcValue.indexOf(')')));
                }
                functions[funcName] = funcValue;
                defining = false;
            }
            if (currentLine[i] === 'd') {
                if (currentLine.indexOf('def') === i) {
                    defining = true;
                    i += 2;
                    continue;
                }
            }

            if (isOperator(currentLine[i]) && currentLine[i + 1] === ' ') {
                var parameters = currentLine.substring(i + 1, currentLine.length - 1).trim().split(' ');
                var numbers = parameters.filter(function (a) {
                    return !isNaN(parseFloat(a)) || functions.hasOwnProperty(a);
                });
                if (functions.hasOwnProperty(numbers[0])) {
                    lineResult = parseFloat(functions[numbers[0]]);
                } else {
                    lineResult = parseFloat(numbers[0]);
                }

                switch (currentLine[i]) {
                    case '+': {
                        for (var j = 1; j < numbers.length; j++) {
                            if (!isNaN(numbers[j])) {
                                lineResult += parseFloat(numbers[j]);
                            } else {
                                lineResult += parseFloat(functions[numbers[j]]);
                            }
                        }
                    }
                        break;
                    case '-': {
                        for (var j = 1; j < numbers.length; j++) {
                            if (!isNaN(numbers[j])) {
                                lineResult -= parseFloat(numbers[j]);
                            } else {
                                lineResult -= parseFloat(functions[numbers[j]]);
                            }
                        }
                    }
                        break;
                    case '*': {
                        for (var j = 1; j < numbers.length; j++) {
                            if (!isNaN(numbers[j])) {
                                lineResult *= parseFloat(numbers[j]);
                            } else {
                                lineResult *= parseFloat(functions[numbers[j]]);
                            }
                        }
                    }
                        break;
                    case '/': {
                        for (var j = 1; j < numbers.length; j++) {
                            if (!isNaN(numbers[j])) {
                                if (parseFloat(numbers[j]) !== 0) {
                                    lineResult = lineResult / parseFloat(numbers[j]);
                                } else {
                                    return errMsg + line;
                                }
                            } else {
                                if (parseFloat(functions[numbers[j]]) !== 0) {
                                    lineResult = Math.floor(lineResult / parseFloat(functions[numbers[j]]));
                                } else {
                                    return errMsg + line + 1;
                                }
                            }
                        }
                    }
                        break;
                }
            }

            if (currentLine[i] === ')') {
                continue;
            }
        }
        line++;
        level = 0;
    }
    return lineResult;
}

console.log(Solve([
                        '(def func -5)',
                      '(+ 3 -func)',


]));