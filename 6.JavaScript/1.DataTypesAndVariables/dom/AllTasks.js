//Task 1--------------All Literals------------------
var arr = ['firstEl', 'secondEl'];
var bool = true;
var integer = 55;
var octalInt = 055;
var hex = 0x3344;
var floatPoint = 55.55;
var floatZeroLeading = .345;
var str = 'hi';
var obj = {
	car: 'someCar',
	year: 2008,
	model: 'GTR',
	hP: 607
};

//Task 2-------------Quoted Text String-------------
var stringQuoted = '"How you doin?", Joey said.';
console.log(stringQuoted);

//Task 3-------------typeof-------------------------
console.log(typeof arr);
console.log(typeof bool);
console.log(typeof integer);
console.log(typeof octalInt);
console.log(typeof hex);
console.log(typeof floatPoint);
console.log(typeof floatZeroLeading);
console.log(typeof str);
console.log(typeof obj);
console.log(typeof stringQuoted);

//Task 4-------------null/undefined------------------
var ud; //asumes value "undefined" by default if not initialized
var n = null;
console.log(typeof ud);
console.log(typeof n);