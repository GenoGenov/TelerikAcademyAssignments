window.onload = function () {
    var highScore = 0;
    var isGameRunning = false;
    if (localStorage.getItem('Snake high score')) {
        highScore = localStorage.getItem('Snake high score');
    } else {
        localStorage.setItem('Snake high score', highScore);
    }
    var higchScoreContainer = document.getElementById('highScoreContainer');
    var highScoreStringDefault = higchScoreContainer.innerHTML;
    higchScoreContainer.innerHTML = highScoreStringDefault + ' ' + (highScore > 0 ? highScore : 'None');

    document.getElementById("startNewGameBtn").addEventListener('click', function () {
        if (!isGameRunning) {
            isGameRunning = true;
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext('2d');

            var isFoodPresent;
            var defaultSpeed = 10;
            var initialPositionX = 100;
            var initialPositionY = 100;
            var gameSpeedIncrease = 0;
            var speedRatio = 1;
            var foodCoords = undefined;
            var currentScore = 0;

            document.getElementById('fastenBtn').addEventListener('click', function () {
                if (gameSpeedIncrease < 170) {
                    gameSpeedIncrease += 15;
                    speedRatio++;
                    updateInfoBox();
                }
            });

            document.getElementById('slowBtn').addEventListener('click', function () {
                if (gameSpeedIncrease > 0) {
                    gameSpeedIncrease -= 15;
                    speedRatio--;
                    updateInfoBox();
                }
            });

            var scoreContainer = document.getElementById('currentScore');
            var scoreDefaultText = 'Current Score:';
            var infoBox = document.getElementById('speedInfo');
            var defaultText = 'Current Speed:';
            infoBox.innerText = defaultText + ' 1x';
            scoreContainer.innerHTML = scoreDefaultText + ' ' + currentScore;
            function updateScoreBox() {
                scoreContainer.innerHTML = scoreDefaultText + ' ' + currentScore;
            }

            function updateInfoBox() {
                infoBox.innerText = defaultText + ' ' + speedRatio + 'x';
            }

            function updateHighScore(score) {
                higchScoreContainer.innerHTML = highScoreStringDefault + ' ' + score;
            }

            var snake = new Object();
            snake.bodyMembers = [];
            snake.bodyMembers[0] = { positionX: 0, positionY: 0, oldX: undefined, oldY: undefined };
            snake.bodyMembersSize = 10;
            snake.speed = 0;
            snake.head = snake.bodyMembers[0];
            snake.currentDirection = 'none';

            document.addEventListener('keyup', function (ev) {
                if (ev.keyCode === 38) {
                    snake.currentDirection = 'up';
                } else if (ev.keyCode === 40) {
                    snake.currentDirection = 'down';
                } else if (ev.keyCode === 37) {
                    snake.currentDirection = 'left';
                } else if (ev.keyCode === 39) {
                    snake.currentDirection = 'right';
                }
            });

            function getRandomCoordinates() {
                var x = Math.floor(Math.random() * (canvas.width - 20 - 20 + 1));
                var y = Math.floor(Math.random() * (canvas.height - 20 - 20 + 1));
                return { x: x, y: y };
            }

            function isGameFieldOccupied(coordinates) {
                var isOccupied = false;
                for (var i = 0; i < snake.bodyMembers.length; i++) {
                    if ((coordinates.x === snake.bodyMembers[i].positionX && coordinates.y === snake.bodyMembers[i].positionY)) {
                        isOccupied = true;
                        break;
                    }
                }
                return isOccupied;
            }

            function initialize() {
                do {
                    foodCoords = getRandomCoordinates();
                } while (isGameFieldOccupied(foodCoords));
                isFoodPresent = false;
                defaultSpeed = 10;
                initialPositionX = 100;
                initialPositionY = 100;
                gameSpeedIncrease = 0;
                speedRatio = 1;
                currentScore = 0;
                snake.speed = defaultSpeed;
                snake.head.positionX = initialPositionX;
                snake.head.positionY = initialPositionY;
                snake.currentDirection = 'right';
                for (var i = 1; i < 6; i++) {
                    snake.bodyMembers[i] = {};
                    snake.bodyMembers[i].positionX = snake.bodyMembers[i - 1].positionX - snake.bodyMembersSize - snake.bodyMembersSize / 2 + 1;
                    snake.bodyMembers[i].positionY = snake.bodyMembers[i - 1].positionY;
                    snake.bodyMembers[i].oldX = undefined;
                    snake.bodyMembers[i].oldY = undefined;
                }
            }

            function appendSnakeBodyPart() {
                var lastBodyPart = snake.bodyMembers[snake.bodyMembers.length - 1];
                snake.bodyMembers.push({ positionX: lastBodyPart.oldX, positionY: lastBodyPart.oldY, oldX: lastBodyPart.oldX, oldY: lastBodyPart.oldY });
            }

            function moveSnake() {
                for (var i = 0; i < snake.bodyMembers.length; i++) {
                    snake.bodyMembers[i].oldX = snake.bodyMembers[i].positionX;
                    snake.bodyMembers[i].oldY = snake.bodyMembers[i].positionY;
                }
                switch (snake.currentDirection) {
                    case 'right': {
                            for (var i = 1; i < snake.bodyMembers.length; i++) {
                                snake.bodyMembers[i].positionX = snake.bodyMembers[i - 1].oldX;
                                snake.bodyMembers[i].positionY = snake.bodyMembers[i - 1].oldY;
                            }
                            snake.head.positionX += snake.speed + snake.bodyMembersSize / 2 + 1;
                        }
                        break;
                    case 'down': {
                            for (var i = 1; i < snake.bodyMembers.length; i++) {
                                snake.bodyMembers[i].positionX = snake.bodyMembers[i - 1].oldX;
                                snake.bodyMembers[i].positionY = snake.bodyMembers[i - 1].oldY;
                            }
                            snake.head.positionY += snake.speed + snake.bodyMembersSize / 2 + 1;
                        }
                        break;
                    case 'left': {
                            for (var i = 1; i < snake.bodyMembers.length; i++) {
                                snake.bodyMembers[i].positionX = snake.bodyMembers[i - 1].oldX;
                                snake.bodyMembers[i].positionY = snake.bodyMembers[i - 1].oldY
                            }
                            snake.head.positionX = snake.head.positionX - snake.speed - snake.bodyMembersSize / 2 - 1;
                        }
                        break;
                    case 'up': {
                            for (var i = 1; i < snake.bodyMembers.length; i++) {
                                snake.bodyMembers[i].positionX = snake.bodyMembers[i - 1].oldX;
                                snake.bodyMembers[i].positionY = snake.bodyMembers[i - 1].oldY;
                            }
                            snake.head.positionY = snake.head.positionY - snake.speed - snake.bodyMembersSize / 2 - 1;
                        }
                        break;
                }

                if (snake.head.positionX >= foodCoords.x - 17 && snake.head.positionX <= foodCoords.x + 17 && snake.head.positionY >= foodCoords.y - 17 && snake.head.positionY <= foodCoords.y + 17) {
                    currentScore += 100;
                    updateScoreBox();
                    appendSnakeBodyPart();
                    isFoodPresent = false;
                }
            }

            function draw() {
                for (var i = 0; i < snake.bodyMembers.length; i++) {
                    ctx.fillRect(snake.bodyMembers[i].positionX, snake.bodyMembers[i].positionY, snake.bodyMembersSize, snake.bodyMembersSize);
                }
                ctx.arc(foodCoords.x, foodCoords.y, 7, 0, 2 * Math.PI);
                ctx.fill();
                isFoodPresent = true;
            }

            function getNextFrame() {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                ctx.beginPath();

                moveSnake();
                if (!isFoodPresent) {
                    do {
                        foodCoords = getRandomCoordinates();
                    } while (isGameFieldOccupied(foodCoords));
                }
                draw();
                for (var i = 1; i < snake.bodyMembers.length; i++) {
                    if ((snake.head.positionX === snake.bodyMembers[i].positionX && snake.head.positionY === snake.bodyMembers[i].positionY) || snake.head.positionX < 0 || snake.head.positionX > canvas.width || snake.head.positionY < 0 || snake.head.positionY > canvas.height) {
                        if (currentScore > localStorage.getItem('Snake high score')) {
                            localStorage.setItem('Snake high score', currentScore);
                            updateHighScore(currentScore);
                            alert("New High Score! Your score: " + currentScore);
                        } else {
                            alert("Game Over! Your score: " + currentScore);
                        }
                        isGameRunning = false;
                        return;
                    }
                }
                setTimeout(getNextFrame, 200 - gameSpeedIncrease);
            }
            initialize();
            getNextFrame();
        }
    });
}