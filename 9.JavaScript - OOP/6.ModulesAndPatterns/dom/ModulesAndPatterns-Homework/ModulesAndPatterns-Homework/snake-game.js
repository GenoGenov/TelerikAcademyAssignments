window.onload = function() {
    var defaultSpeed = 10;
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');

    var utils = (function () {
        var getRandomCoordinates = function () {
            var x = Math.floor(Math.random() * (canvas.width - 20 - 20 + 1));
            var y = Math.floor(Math.random() * (canvas.height - 20 - 20 + 1));
            return { x: x, y: y };
        }
        return {
            getRandomCoordinates: getRandomCoordinates
        }
    }());

    var foodManager = (function() {
        var isFoodPresent;
        var coords = {
            x: 0,
            y: 0
        };

        var initialize = function() {
            do {
                coords = utils.getRandomCoordinates();
            } while (snake.occupies(coords));
            isFoodPresent = false;
        };
        var draw = function() {
            ctx.arc(coords.x, coords.y, 7, 0, 2 * Math.PI);
            ctx.fill();
            isFoodPresent = true;
        };
        var checkFoodAvailable = function() {
            if (!isFoodPresent) {
                do {
                    coords = utils.getRandomCoordinates();
                } while (snake.occupies(coords));
            }
        };
        var notifyFoodEaten = function() {
            isFoodPresent = false;
            checkFoodAvailable();
            draw();
        };

        var getFoodCoords=function() {
            return coords;
        }
        return {
            init: initialize,
            draw: draw,
            checkFood: checkFoodAvailable,
            getFoodCoords: getFoodCoords,
            notifyFoodEaten: notifyFoodEaten
        };
    }());

    var snake = (function (foodMgr, ctx, x, y, speed) {
        var bodyMembers = [];
        var bodyMembersSize = 10;
        bodyMembers[0] = { positionX: 0, positionY: 0, oldX: undefined, oldY: undefined };
        var head = bodyMembers[0];
        var currentDirection = 'none';


        var initialize = function () {
            var initialPositionX = x;
            var initialPositionY = y;
            speed = defaultSpeed;
            head.positionX = initialPositionX;
            head.positionY = initialPositionY;
            currentDirection = 'right';
            for (var i = 1; i < 6; i++) {
                bodyMembers[i] = {};
                bodyMembers[i].positionX = bodyMembers[i - 1].positionX -
                    bodyMembersSize - bodyMembersSize / 2 + 1;
                bodyMembers[i].positionY = bodyMembers[i - 1].positionY;
                bodyMembers[i].oldX = undefined;
                bodyMembers[i].oldY = undefined;
            }
        };

        var appendSnakeBodyPart = function () {
            var lastBodyPart = bodyMembers[bodyMembers.length - 1];
            bodyMembers.push(
            {
                positionX: lastBodyPart.oldX,
                positionY: lastBodyPart.oldY,
                oldX: lastBodyPart.oldX,
                oldY: lastBodyPart.oldY
            });
        };

        var moveSnake = function () {
            var i;
            for (i = 0; i < bodyMembers.length; i++) {
                bodyMembers[i].oldX = bodyMembers[i].positionX;
                bodyMembers[i].oldY = bodyMembers[i].positionY;
            }
            switch (currentDirection) {
                case 'right':
                    {
                        for (i = 1; i < bodyMembers.length; i++) {
                            bodyMembers[i].positionX = bodyMembers[i - 1].oldX;
                            bodyMembers[i].positionY = bodyMembers[i - 1].oldY;
                        }
                        head.positionX += speed + bodyMembersSize / 2 + 1;
                    }
                    break;
                case 'down':
                    {
                        for (i = 1; i < bodyMembers.length; i++) {
                            bodyMembers[i].positionX = bodyMembers[i - 1].oldX;
                            bodyMembers[i].positionY = bodyMembers[i - 1].oldY;
                        }
                        head.positionY += speed + bodyMembersSize / 2 + 1;
                    }
                    break;
                case 'left':
                    {
                        for (i = 1; i < bodyMembers.length; i++) {
                            bodyMembers[i].positionX = bodyMembers[i - 1].oldX;
                            bodyMembers[i].positionY = bodyMembers[i - 1].oldY;
                        }
                        head.positionX = head.positionX - speed - bodyMembersSize / 2 - 1;
                    }
                    break;
                case 'up':
                    {
                        for (i = 1; i < bodyMembers.length; i++) {
                            bodyMembers[i].positionX = bodyMembers[i - 1].oldX;
                            bodyMembers[i].positionY = bodyMembers[i - 1].oldY;
                        }
                        head.positionY = head.positionY - speed - bodyMembersSize / 2 - 1;
                    }
                    break;
            }
            var foodCoords = foodMgr.getFoodCoords();
            if (head.positionX >= foodCoords.x - 17 &&
                head.positionX <= foodCoords.x + 17 &&
                head.positionY >= foodCoords.y - 17 &&
                head.positionY <= foodCoords.y + 17) {
                appendSnakeBodyPart();
                foodMgr.notifyFoodEaten();
            }
        };

        document.addEventListener('keyup', function (ev) {
            if (ev.keyCode === 38) {
                currentDirection = 'up';
            } else if (ev.keyCode === 40) {
                currentDirection = 'down';
            } else if (ev.keyCode === 37) {
                currentDirection = 'left';
            } else if (ev.keyCode === 39) {
                currentDirection = 'right';
            }
        });

        function isGameFieldOccupied(coordinates) {
            var isOccupied = false;
            for (var i = 0; i < bodyMembers.length; i++) {
                if ((coordinates.x === bodyMembers[i].positionX && coordinates.y === bodyMembers[i].positionY)) {
                    isOccupied = true;
                    break;
                }
            }
            return isOccupied;
        }

        var draw = function () {
            for (var i = 0; i < bodyMembers.length; i++) {
                ctx.fillRect(bodyMembers[i].positionX, bodyMembers[i].positionY, bodyMembersSize, bodyMembersSize);
            }
        };
        var checkCollision = function () {
            for (var i = 1; i < bodyMembers.length; i++) {
                if ((head.positionX === bodyMembers[i].positionX &&
                        head.positionY === bodyMembers[i].positionY) ||
                    head.positionX < 0 ||
                    head.positionX > canvas.width ||
                    head.positionY < 0 ||
                    head.positionY > canvas.height) {

                    alert("Game Over! Your score: ");
                    return true;
                }
            }
        };

        return {
            init: initialize,
            appendPart: appendSnakeBodyPart,
            move: moveSnake,
            occupies: isGameFieldOccupied,
            draw: draw,
            checkCollision: checkCollision
        };
    }(foodManager,ctx,100,100,defaultSpeed));

    var gameEngine = (function(ctx,snake,foodMgr) {
        var defaultSpeed = 10;
        
        function initialize() {
            snake.init();
            foodMgr.init();

        }
        function draw() {
            snake.draw();
            foodMgr.draw();
        }

        function getNextFrame() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            ctx.beginPath();
            snake.move();
            if (snake.checkCollision()) {
                return;
            }

            foodMgr.checkFood();
            draw();

            setTimeout(getNextFrame, 200);
        }
        var run=function() {
            initialize();
            getNextFrame();
        }

        return {
            run: run,
        }
    }(ctx,snake,foodManager));
    
    gameEngine.run();
}