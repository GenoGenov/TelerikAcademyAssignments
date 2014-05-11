function getRoots() {
	var a=jsConsole.readInteger('#a');
	var b=jsConsole.readInteger('#b');
	var c=jsConsole.readInteger('#c');
	var D = b * b - 4 * a * c;
	if (D > 0) {
		var root1 = (-b + Math.Sqrt(D)) / 2.0 * a;
		var root2 = (-b - Math.Sqrt(D)) / 2.0 * a;
		jsConsole.writeLine('First root: ' + root1 + 'Second root: ' + root2);
	}
	if (D === 0) {
		var root = (-b) / 2.0 * a;
		jsConsole.writeLine('Single root: ' + root);
	}
	if (D < 0) {
		jsConsole.writeLine('No real roots!');
	}
}