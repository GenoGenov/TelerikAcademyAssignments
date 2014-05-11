var vars = new Array(1, 7, 16, 4, 5);

console.log(vars.sort(function(a, b) {
	return b - a;
})[0]);