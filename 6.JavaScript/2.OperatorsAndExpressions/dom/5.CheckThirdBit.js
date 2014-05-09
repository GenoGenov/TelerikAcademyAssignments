function checkThirdBit (num) {
	var mask=1<<2;
	var thirdBit=(num & mask)>>2;
	return thirdBit===1;
}

console.log(checkThirdBit(2));
console.log(checkThirdBit(5));