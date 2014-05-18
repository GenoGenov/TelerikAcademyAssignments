function Point(x, y) {
    this.x = x;
    this.y = y;
}

function Line(startPoint, endPoint) {
    this.startPoint = startPoint;
    this.endPoint = endPoint;
    this.length = function () {
        return Math.sqrt((this.endPoint.x - this.startPoint.x) * (this.endPoint.x - this.startPoint.x) + (this.endPoint.y - this.startPoint.y) * (this.endPoint.y - this.startPoint.y));
    }
}

function canFormTriangle(a, b, c) {
    return a.length() + b.length() > c.length() && a.length() + c.length() > b.length() && b.length() + c.length() > a.length();
}

var a = new Line(new Point(4, 7), new Point(2, 3));
var b = new Line(new Point(1, 9), new Point(4, 8));
var c = new Line(new Point(4, 1), new Point(2, 0));

console.log(canFormTriangle(a, b, c));