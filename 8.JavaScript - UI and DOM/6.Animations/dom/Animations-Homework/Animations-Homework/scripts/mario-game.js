window.onload = function () {
    var paper = Raphael(0, 0, window.innerWidth, 800);
    paper.image('sources/super-mario-background.png', 0, 0, paper.width, paper.height);


    var stage = new Kinetic.Stage({
        container: 'container',
        width: window.innerWidth,
        height: 800
    });

    var layer = new Kinetic.Layer();
    var rotate = false;
    var marioSprite = new Image();
    marioSprite.onload = function () {
        var mario = new Kinetic.Sprite({
            x: window.innerWidth/2,
            y: 500,
            image: marioSprite,
            animation: 'idle',
            animations: {
                idle: [
                  600, 660, 170, 250,

                ],
                move: [
                  // x, y, width, height (3 frames)
                  560, 985, 240, 260,
                  25, 970, 235, 265,
                  860, 660, 200, 220
                ]
            },
            frameRate: 2,
            frameIndex: 0,
          
        });
        layer.add(mario);
        stage.add(layer);


        mario.start();

        var frameCount = 0;

        mario.on('frameIndexChange', function (evt) {
            if (mario.animation() === 'move' && ++frameCount > 3) {
                mario.animation('idle');
                mario.scaleX(1);
                if(rotate===true){
                    mario.scaleX(-1);
                }
                frameCount = 0;
            }
        });

        function onKeyDown(evt) {
            switch (evt.keyCode) {
                case 37:
                    if(rotate===true){
                        mario.scaleX(-1);
                    }
                    mario.setX(mario.attrs.x -= 50);
                    mario.attrs.animation = "move";
                    rotate = false;
                    break;
                case 39:
                    rotate = true;
                    mario.setX(mario.attrs.x += 50);
                    mario.scaleX(-1);
                    mario.attrs.animation = "move";
                    break;
            }
        }

        window.addEventListener('keydown', onKeyDown);

    }
    marioSprite.src = 'sources/mario-sprites.png';
  

}