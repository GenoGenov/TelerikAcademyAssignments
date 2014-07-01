var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');

var ShapesDrawer = (function () {
    function Context(context) {
        this.ctx = context;
    }
    function Rect(x, y, width, height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    function Line(x1, y1, x2, y2) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    function Circle(x, y, r) {
        this.x = x;
        this.y = y;
        this.r = r;
    }

    Context.prototype.drawLine = function (x1, y1, x2, y2) {
        this.ctx = ctx;
        var line = new Line(x1, y1, x2, y2);
        ctx.moveTo(line.x1, line.y1);
        ctx.lineTo(line.x2, line.y2);
        ctx.stroke();
    }

    Context.prototype.drawRect = function (x, y, width, height) {
        this.ctx = ctx;
        var rect = new Rect(x, y, width, height);
        ctx.rect(rect.x, rect.y, rect.width, rect.height);
        ctx.stroke();
    }

    Context.prototype.drawCircle = function (x, y, r) {
        this.ctx = ctx;
        var circle = new Circle(x, y, r);
        ctx.arc(circle.x, circle.y, circle.r, 0, 2 * Math.PI);
        ctx.stroke();
    }

    return Context;
}());

var drawer = new ShapesDrawer(ctx);
drawer.drawCircle(30, 40, 30);
drawer.drawRect(90, 30, 40, 40);
drawer.drawLine(30, 40, 110, 50);