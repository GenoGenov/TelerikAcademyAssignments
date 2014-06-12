window.onload = function () {
    'use strict';
    var centerPoint = {
        x: window.innerWidth / 2,
        y: window.innerHeight / 2,
        r: 200
    };
    var angle = 0;

    function getNextCoordinates(trajectory) {
        return {
            x: trajectory.x + trajectory.r * Math.cos(trajectory.angle),
            y: trajectory.y + trajectory.r * Math.sin(trajectory.angle)
        };
    }

    function generateRandomDivs() {
        var divsCount = 4;
        var div = document.createElement('div');
        var strong = document.createElement('strong');
        var result = [];
        strong.innerHTML = 'div';
        for (var i = 0; i < divsCount; i++) {
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
            result.push(div.cloneNode(true));
        }
        return result;
    }

    var divs = generateRandomDivs();

    function animateDivsMovement() {
        var frag = document.createDocumentFragment();
        for (var i = 0; i < divs.length; i++) {
            frag.appendChild(divs[i]);
        }
        document.body.appendChild(frag);
        angle += 0.05;
        var len = divs.length;
        for (var i = 0; i < len; i++) {
            var newCoords = getNextCoordinates({
                x: centerPoint.x,
                y: centerPoint.y,
                r: centerPoint.r,
                angle: angle + i * 2 * Math.PI / len
            });
            divs[i].style.left = newCoords.x + 'px';
            divs[i].style.bottom = newCoords.y + 'px';
        }
        setTimeout(animateDivsMovement, 20);
    }
    animateDivsMovement();
}

