function checkDivisible(num) {
	return num % (7 * 5) === 0;
}
for (var i = 100; i >= 0; i--) {
	console.log(i + ' ' + checkDivisible(i));
}