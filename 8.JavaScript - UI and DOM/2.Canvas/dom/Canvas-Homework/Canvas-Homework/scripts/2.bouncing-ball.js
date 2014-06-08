window.onload = function () {

    var infoBox = document.getElementById('speedInfo');
    var defaultText = infoBox.innerText;
    infoBox.innerText = defaultText + ' 1x';

    function updateInfoBox() {
        infoBox.innerText = defaultText + ' ' + speedRatio + 'x';
    }

    var x = 50,
       y = 50,
       speedX = 1,
       speedY = 1,
       speedRatio = 1;


    document.getElementById('fastenBtn').addEventListener('click', function () {
        if (speedRatio < 10) {
            speedRatio += 1;
            updateInfoBox();
        }

    });

    document.getElementById('slowBtn').addEventListener('click', function () {
        if (speedRatio > 0) {
            speedRatio -= 1;
            updateInfoBox();
        }

    });

    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext('2d');



    function UpdateFrame() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.beginPath();
        if (x + 10 + speedX > canvas.width || x - 10 + speedX < 0) {
            speedX = -speedX;
        }
        if (y - 10 + speedY < 0 || y + 10 + speedY > canvas.height) {
            speedY = -speedY;
        }
        x += speedX * speedRatio;
        y += speedY * speedRatio;
        ctx.arc(x, y, 10, 0, 2 * Math.PI);
        ctx.fill();

        setTimeout(UpdateFrame, 5);
    }

    UpdateFrame();
}
