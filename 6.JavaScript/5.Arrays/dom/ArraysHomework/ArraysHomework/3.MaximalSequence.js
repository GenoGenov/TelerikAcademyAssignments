var arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];

var max = arr[0];
var current;
var curArr = [];
var maxArr = [];
for (var i = 0; i < arr.length - 1; i++) {
    current = arr[i];
    curArr.push(arr[i]);
    if (current > max) {
        max = current;
    }
    for (var j = i + 1; j < arr.length; j++) {
        if (arr[j] === curArr[0]) {
            current += arr[j];
            curArr.push(arr[j]);
            if (current > max) {
                max = current;
            }
        }
        else {
            if (current >= max) {
                maxArr = curArr;
            }
            curArr = [];
            break;
        }

    }
}
console.log(maxArr);