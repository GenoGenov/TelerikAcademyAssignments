var a = 9,
	b = 20,
	c = 8;
var biggest;

if (a > b) {
	if (a > c) {
		biggest = a;
	} else {
		biggest = c;
	}
} else if (b > c) {
	biggest = b;
} else {
	biggest = c;
}
console.log('The biggest of the three is '+ biggest);