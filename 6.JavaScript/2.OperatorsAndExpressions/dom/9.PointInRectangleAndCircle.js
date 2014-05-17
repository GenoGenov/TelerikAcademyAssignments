var center = {
	x: 1,
	y: 1
};
var point;
top = 1,
left = -1,
width = 6,
height = 2,
radius = 3;

function isInCircle(point) {
	return ((point.x - center.x) * (point.x - center.x) + (point.y - center.y) * (point.y - center.y)) <= radius * radius;
}

function isInRectangle(point) {
	return ((point.x >= left) && (point.x <= left + width)) && ((point.y <= top) && (point.y >= top - height));
}

point = {
	x: 10,
	y: 10
};

console.log('The point is ' + (isInCircle(point) ? 'in ' : 'out ') + 'the circle and ' + (isInRectangle(point) ? 'in ' : 'out ') + 'the rectangle');

point = {
	x: 3,
	y: 1
};

console.log('The point is ' + (isInCircle(point) ? 'in ' : 'out ') + 'the circle and ' + (isInRectangle(point) ? 'in ' : 'out ') + 'the rectangle');