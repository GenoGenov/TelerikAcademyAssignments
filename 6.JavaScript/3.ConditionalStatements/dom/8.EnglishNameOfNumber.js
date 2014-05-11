function switchUnits(a) {
	switch (a) {
		default: break;
		case 1:
			console.log('One');
			break;
		case 2:
			console.log('Two');
			break;
		case 3:
			console.log('Three');
			break;
		case 4:
			console.log('Four');
			break;
		case 5:
			console.log('Five');
			break;
		case 6:
			console.log('Six');
			break;
		case 7:
			console.log('Seven');
			break;
		case 8:
			console.log('Eight');
			break;
		case 9:
			console.log('Nine');
			break;
	}
}

function switchTensSpecial(a) {
	switch (a) {
		default: break;
		case 1:
			console.log('Eleven');
			break;
		case 2:
			console.log('Twelve');
			break;
		case 3:
			console.log('Thirteen');
			break;
		case 4:
			console.log('Forteen');
			break;
		case 5:
			console.log('Fifteen');
			break;
		case 6:
			console.log('Sixteen');
			break;
		case 7:
			console.log('Seventeen');
			break;
		case 8:
			console.log('Eighteen');
			break;
		case 9:
			console.log('Nineteen');
			break;
	}
}

function switchTens(a) {
	switch (a) {
		default: break;
		case 1:
			console.log('Ten');
			break;
		case 2:
			console.log('Twenty');
			break;
		case 3:
			console.log('Thirty');
			break;
		case 4:
			console.log('Forty');
			break;
		case 5:
			console.log('Fifty');
			break;
		case 6:
			console.log('Sixty');
			break;
		case 7:
			console.log('Seventy');
			break;
		case 8:
			console.log('Eighty');
			break;
		case 9:
			console.log('Ninety');
			break;
	}
}

function switchHundreds(a) {
	switch (a) {
		default: break;
		case 1:
			console.log('One hundred ');
			break;
		case 2:
			console.log('Two hundred ');
			break;
		case 3:
			console.log('Three jundred ');
			break;
		case 4:
			console.log('Four hundred ');
			break;
		case 5:
			console.log('Five hundred ');
			break;
		case 6:
			console.log('Six hundred ');
			break;
		case 7:
			console.log('Seven hundred ');
			break;
		case 8:
			console.log('Eight hundred ');
			break;
		case 9:
			console.log('Nine hundred ');
			break;
	}
}

var number = 711;

var a = number % 10;
var temp = Math.floor(number / 10);
var b = temp % 10;
temp = Math.floor(temp / 10);
var c = temp;

if (number === 0) {
	console.log("Zero");
} else if (number > 0 && number < 10) {
	switchUnits(a);
} else if (number === 10) {
	console.log('Ten');
} else if (number > 10 && number < 20) {
	switchTensSpecial(number);
} else if (number > 19 && number < 100) {
	switchTens(b);
	switchUnits(a);
} else if (number > 99 && b === 0) {
	switchHundreds(c);
	if (a !== 0) {
		console.log('And ');
	}
	switchUnits(a);
} else if (number > 99 && b === 1) {
	switchHundreds(c);
	console.log('And ');
	if (a === 0) {
		console.log('Ten');
	} else {
		switchTensSpecial(a);
	}

} else if (number > 119 && a !== 0) {
	switchHundreds(c);

	switchTens(b);

	switchUnits(a);
} else if (number > 119 && a === 0) {
	switchHundreds(a);
	console.log(' And ');
	switchTens(b);
}