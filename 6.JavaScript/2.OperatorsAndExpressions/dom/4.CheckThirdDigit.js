function checkThirdDigit(num) {
	var stringNum = num.toString();
	console.log(parseInt(stringNum[stringNum.length - 3]) === 7);
}

checkThirdDigit(123744);
checkThirdDigit(17733333);