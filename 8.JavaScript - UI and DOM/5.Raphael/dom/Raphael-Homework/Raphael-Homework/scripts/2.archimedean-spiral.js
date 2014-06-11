var paper = Raphael(20, 20, 1000, 1000);

var startX = 500;
var startY = 500;

for (i = 0; i < 3500; i++) {
    var angle = 0.008 * i;
    var x = (1 + 10*angle) * Math.cos(angle)+startX;
    var y = (1 + 10*angle) * Math.sin(angle)+startY;
    paper.circle(x, y, 1);
}