window.onload = function () {

    function drawElipse(ctx, centerX, centerY, radiusX, radiusY, startAngle, endAngle) {
        var axisRatio = radiusY / radiusX;
        startAngle = (startAngle || 0);
        endAngle = (endAngle || (2 * Math.PI));

        ctx.save();
        ctx.scale(1, axisRatio);
        
        ctx.arc(centerX, centerY / axisRatio, radiusX, startAngle, endAngle);
        ctx.restore();
    }

    function drawLine(ctx, startX, startY, endX, endY) {
        ctx.beginPath();
        ctx.moveTo(startX, startY);
        ctx.lineTo(endX, endY);
        ctx.stroke();
    }

    var canvas = document.getElementById("canvas").getContext('2d');
    canvas.fillStyle = 'lightblue';
    canvas.strokeStyle = 'blue';
    canvas.lineWidth = 2;
    canvas.save();

    //head

    drawElipse(canvas, 100, 200, 50, 50);
    canvas.stroke();
    canvas.fill();

    canvas.beginPath();
    drawElipse(canvas, 100 - 25, 200 - 10, 10, 5);
    canvas.stroke();
    canvas.fill();
    canvas.beginPath();
    drawElipse(canvas, 100 - 30, 200 - 10, 1, 2);
    canvas.stroke();
    canvas.fill();

    canvas.beginPath();
    drawElipse(canvas, 100 + 25, 200 - 10, 10, 5);
    canvas.stroke();
    canvas.fill();
    canvas.beginPath();
    drawElipse(canvas, 100 + 20, 200 - 10, 1, 2);
    canvas.stroke();
    canvas.fill();

    canvas.fillStyle = 'rgb(57,102,147)';
    canvas.strokeStyle = 'black';
    canvas.beginPath();
    drawElipse(canvas, 98, 150, 60, 15);
    canvas.stroke();
    canvas.fill();
    canvas.beginPath();
    canvas.moveTo(80, 137);
    canvas.lineTo(80, 75);
    canvas.stroke();
    canvas.fill();
    
    canvas.beginPath();
    canvas.moveTo(130, 76);
    canvas.lineTo(130, 138);
    canvas.quadraticCurveTo(100, 150, 80, 137);
    canvas.fill();
    canvas.stroke();

    canvas.beginPath();
    drawElipse(canvas, 105, 78, 25, 10);
    canvas.fill();
    canvas.stroke();
   
    

    canvas.beginPath();
    canvas.moveTo(100, 220);
    canvas.lineTo(90, 220);
    canvas.lineTo(100, 200);
    canvas.stroke();

    canvas.beginPath();
    canvas.save();
    canvas.rotate(8*Math.PI/180);
    drawElipse(canvas, 130, 220, 20, 5);
    canvas.stroke();
    canvas.fill();
    canvas.restore();

    
    //bicycle

    canvas.beginPath();
    canvas.fillStyle = 'lightblue';
    drawElipse(canvas, 100, 500, 70, 70);
    canvas.fill();
    canvas.moveTo(270, 390);
    canvas.lineTo(100, 500);
    canvas.lineTo(330, 500);
    canvas.closePath();
    
    var x = 270 * 0.9,
        y = 390 * 0.9;
    canvas.lineTo(x, y);
    canvas.lineTo(x - 30, y);
    canvas.lineTo(x + 30, y);
    x = 270;
    y = 390;
    canvas.moveTo(x, y);
    canvas.lineTo(x + 220, y);
    canvas.lineTo(330, 500);
    canvas.stroke();
    canvas.beginPath();
    drawElipse(canvas, 330, 500, 30, 30);
    canvas.moveTo(305, 485);
    canvas.lineTo(270, 450);
    canvas.moveTo(358, 510);
    canvas.lineTo(385, 540);
    canvas.moveTo(530, 500);
    canvas.beginPath();
    drawElipse(canvas, 530, 500, 70, 70);
    canvas.fill();
    canvas.stroke();
    canvas.beginPath();
    canvas.moveTo(530, 500);
    x+=220;
    canvas.lineTo(x, y);
    
    x = x * 0.96;
    y = y * 0.9;
    canvas.lineTo(x, y);
    canvas.lineTo(x - 60, y + 7);
    canvas.moveTo(x, y);
    canvas.lineTo(x + 60, y - 25);
    canvas.stroke();

    //house 
    canvas.beginPath();
    x = 700;
    y = 200;
    canvas.fillStyle = 'RGB(149,89,89)';
    canvas.strokeStyle = 'black';


    canvas.fillRect(x, y, 300, 250);
    canvas.strokeRect(x, y, 300, 250);

    canvas.beginPath()
    canvas.moveTo(x, y);
    canvas.lineTo(x + 150, y - 130);
    canvas.lineTo(x + 300, y);
    canvas.fill();
    canvas.stroke();

    canvas.fillRect(x + 220, y - 110, 40, 80);
    drawElipse(canvas, x + 240, y - 110, 20, 5, true);
    canvas.stroke();
    canvas.fill();
    canvas.beginPath();
    drawLine(canvas, x + 220, y - 110, x + 220, y - 20);
    canvas.stroke();
    canvas.fill();
    canvas.beginPath();
    drawLine(canvas, x + 260, y - 110, x + 260, y - 20);
    canvas.stroke();
    canvas.fill();
    canvas.beginPath();

    drawWindow({ x: x + 30, y: y + 30 });
    drawWindow({ x: x + 165, y: y + 30 });
    drawWindow({ x: x + 165, y: y + 125 });

    drawElipse(canvas, x + 82, y + 150, 40, 20, false, Math.PI, 2 * Math.PI);
    canvas.beginPath()
    canvas.moveTo(x + 42, y + 150);
    canvas.lineTo(x + 42, y + 250);
    canvas.moveTo(x + 122, y + 150);
    canvas.lineTo(x + 122, y + 250);
    canvas.moveTo(x + 82, y + 130);
    canvas.lineTo(x + 82, y + 250);
    canvas.stroke();
    canvas.beginPath();
    drawCircle(canvas, x + 70, y + 210, 5, false);
    canvas.beginPath();
    drawCircle(canvas, x + 94, y + 210, 5, false);

    function drawWindow(startPoint) {
        var x = startPoint.x,
            y = startPoint.y;

        canvas.fillStyle = 'black';

        canvas.fillRect(x, y, 50, 30);
        canvas.fillRect(x + 55, y, 50, 30);
        canvas.fillRect(x, y + 35, 50, 30);
        canvas.fillRect(x + 55, y + 35, 50, 30);
    }
}

