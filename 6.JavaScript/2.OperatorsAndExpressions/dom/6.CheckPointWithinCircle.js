var circle = {
	center: {
		x: 0,
		y: 0
	},
	radius: 5
};

function checkPointWithinCircle(point) {

	function checkDistance2D(firstPoint, secondPoint) {
		return Math.sqrt((secondPoint.x - firstPoint.x) * (secondPoint.x - firstPoint.x) + (secondPoint.y - firstPoint.y) * (secondPoint.y - firstPoint.y));
	}

	console.log(checkDistance2D(circle.center, point) < circle.radius);
}

var point1 = {
	x: 9,
	y: 17
};
var point2 = {
	x: 1,
	y: 1
};

checkPointWithinCircle(point1);
checkPointWithinCircle(point2);