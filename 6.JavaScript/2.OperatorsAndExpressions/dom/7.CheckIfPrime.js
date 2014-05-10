function checkPrime(num) {
	for (var i = 2; i < num; i++) {
		if (num % i === 0) {
			return false;
		}
	}
	return true;
}

console.log(checkPrime(37));
console.log(checkPrime(38));