var movingShapes = (function () {
    var centerPoint = {
        x: window.innerWidth / 2,
        y: window.innerHeight / 2,
        r: 200
    };
    var angle = 0;

    var anglePoints = {
        topLeft: {
            x: centerPoint.x - centerPoint.r,
            y: centerPoint.y - centerPoint.r,
        },
        topRight: {
            x: centerPoint.x + centerPoint.r,
            y: centerPoint.y - centerPoint.r,
        },
        botLeft: {
            x: centerPoint.x - centerPoint.r,
            y: centerPoint.y + centerPoint.r,
        },
        botRight: {
            x: centerPoint.x + centerPoint.r,
            y: centerPoint.y + centerPoint.r,
        }
    }

    function getNextCoordinates(trajectory) {
        return {
            x: trajectory.x + trajectory.r * Math.cos(trajectory.angle),
            y: trajectory.y + trajectory.r * Math.sin(trajectory.angle)
        };
    }

    function getNextCoordinatesRectangular(element, trajectory) {
        var curX = parseFloat(getComputedStyle(element).left);
        var curY = parseFloat(getComputedStyle(element).top);

        if (curX <= anglePoints.topLeft.x && curY <= anglePoints.topLeft.y) {
            return {
                x: curX + 2,
                y: anglePoints.topLeft.y,
            }
        } else if (curX >= anglePoints.topRight.x && curY <= anglePoints.topRight.y) {
            return {
                x: anglePoints.topRight.x,
                y: curY + 2,
            }
        } else if (curX >= anglePoints.botRight.x && curY >= anglePoints.botRight.y) {
            return {
                x: curX - 2,
                y: anglePoints.botRight.y,
            }
        } else if (curX <= anglePoints.botLeft.x && curY >= anglePoints.botLeft.y) {
            return {
                x: anglePoints.botLeft.x,
                y: curY - 2,
            }
        } else if (curX === anglePoints.botLeft.x) {
            return {
                x: anglePoints.botLeft.x,
                y: curY - 2,
            }
        } else if (curY === anglePoints.topLeft.y) {
            return {
                x: curX + 2,
                y: anglePoints.topLeft.y,
            }
        } else if (curY + parseFloat(getComputedStyle(element).height) >= anglePoints.botRight.y) {
            return {
                x: curX - 2,
                y: anglePoints.botRight.y,
            }
        } else if (curX + parseFloat(getComputedStyle(element).width) >= anglePoints.topRight.x) {
            return {
                x: anglePoints.topRight.x,
                y: curY + 2,
            }
        } else {
            return {
                x: anglePoints.botLeft.x,
                y: anglePoints.botLeft.y,
            }
        }

    }

    function generateRandomDiv(divsCount) {
        divsCount = divsCount || 1;
        var div = document.createElement('div');
        var strong = document.createElement('strong');
        strong.innerHTML = 'div';
        div.style.width = 150 + 'px';
        div.style.height = 150 + 'px';
        div.style.backgroundColor = getRandomColor(true);
        div.style.color = getRandomColor();
        div.style.position = 'absolute';
        div.style.borderWidth = 3 + 'px';
        div.style.borderRadius = 15 + 'px';
        div.style.borderColor = getRandomColor();
        div.style.borderStyle = 'solid';
        div.appendChild(strong);
        return div;
    }


    function animateDivsMovementCircular() {
        var frag = document.createDocumentFragment();
        for (var i = 0; i < divsCircular.length; i++) {
            frag.appendChild(divsCircular[i]);
        }
        document.body.appendChild(frag);
        angle += 0.05;
        var len = divsCircular.length;
        for (var i = 0; i < len; i++) {
            var newCoords = getNextCoordinates({
                x: centerPoint.x,
                y: centerPoint.y,
                r: centerPoint.r,
                angle: angle + i * 2 * Math.PI / len
            });
            divsCircular[i].style.left = newCoords.x + 'px';
            divsCircular[i].style.bottom = newCoords.y + 'px';
        }
        setTimeout(animateDivsMovementCircular, 20);
    }

    function animateDivsMovementRectangular() {
        var frag = document.createDocumentFragment();
        for (var i = 0; i < divsRectangular.length; i++) {
            frag.appendChild(divsRectangular[i]);
        }
        document.body.appendChild(frag);
        var len = divsRectangular.length;
        for (var i = 0; i < len; i++) {
            var newCoords = getNextCoordinatesRectangular(divsRectangular[i],
                {
                    x: centerPoint.x,
                    y: centerPoint.y,
                    r: centerPoint.r,
                });
            divsRectangular[i].style.left = newCoords.x + 'px';
            divsRectangular[i].style.top = newCoords.y + 'px';
        }
        setTimeout(animateDivsMovementRectangular, 2);
    }

    var divsRectangular = [];
    divsRectangular.push(generateRandomDiv());
    var divsCircular = [];
    divsCircular.push(generateRandomDiv());

    animateDivsMovementCircular();
    animateDivsMovementRectangular();

    function addShapes(trajectory){
        if (trajectory==='ellipse') {
            divsCircular.push(generateRandomDiv());
        }else if(trajectory==='rect'){
            divsRectangular.push(generateRandomDiv());
        }
    }

    return {
        add:addShapes
    }
}());

var addCircBtn = document.getElementById('addCircular').addEventListener('click', function () {
    movingShapes.add('ellipse');
});

var addRectBtn = document.getElementById('addRectangular').addEventListener('click', function () {
    movingShapes.add('rect');
})
