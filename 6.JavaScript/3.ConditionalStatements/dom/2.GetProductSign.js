var a = 3,
	b = -5,
	c = -7;

var minusCount = 0;

var arr = new Array(a, b, c);

for (var i in arr) {
	if (arr[i] < 0) {
		minusCount++;
	}
}

if (minusCount % 2 === 0) {
	console.log('positive');
} else {
	console.log('negative');
}