var arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

arr.map(Number);

var checked = [];
var maxNum, maxTimes=0, curTimes=0;

for (var i = 0; i < arr.length; i++) {
    if (checked.indexOf(arr[i]) === -1) {
        checked.push(arr[i]);
        curTimes = arr.filter(function (a) {
            return a === arr[i];
        }).length;
        if (curTimes > maxTimes) {
            maxNum = arr[i];
            maxTimes = curTimes;
        }
    }
}

console.log('Number: '+maxNum);
console.log(maxTimes+' Times');