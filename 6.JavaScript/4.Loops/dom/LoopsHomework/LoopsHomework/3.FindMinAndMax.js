var arr = [2, 8, 3, 19, 4, 2, 8, 99, 322, 11111111111, 3, 7, 0, 3, 5, 7, , 3, 46, 4];
var min = arr[0];
var max = arr[0];

for (var i in arr) {
    if (arr[i] > max) {
        max = arr[i];
    }
    if (arr[i] < min) {
        min = arr[i];
    }
}

console.log(min);
console.log(max);