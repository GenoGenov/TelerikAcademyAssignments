var a = 7,
	b = 3;

if (a > b) {
	var temp = a;
	a = b;
	b = temp;
}

console.log('a = ' + a);
console.log('b = ' + b);