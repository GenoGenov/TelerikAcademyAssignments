var firstArr = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'];
var secondArr = ['a', 'g', 's', 'y', 'e', 'r', 'c', 'z', 'x', 's', 'g'];

for (var i = 0; i < Math.min(firstArr.length, secondArr.length) ; i++) {
    console.log(firstArr[i] >= secondArr[i]? firstArr[i] + ' >= ' + secondArr[i]:firstArr[i] + ' < ' + secondArr[i]);
}