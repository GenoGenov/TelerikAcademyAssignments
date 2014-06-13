window.onload = function () {
    var interval = setInterval(nextSlide, 5000);
    var container = $('#container').css({
        position: 'relative',
        width: '700px',
        margin: '0 auto'
    });
    container.find('img')
    //.first().addClass('current');

    var prevBtn = $('<button>').attr('id', 'previous');
    prevBtn.html('Previous').appendTo('#container');

    $('<div>').attr('id', 'image-holder').css({
        position: 'relative',
        border: '1px solid black',
        width: '500px',
        height: '500px',
        display: 'inline-block'
    }).appendTo('#container');

    container.find('img').first().addClass('current').appendTo('#image-holder');

    var nextBtn = $('<button>').attr('id', 'next');
    nextBtn.html('Next').appendTo('#container');

    prevBtn.on('click', function (ev) {
        nextSlide(true);

    });

    nextBtn.on('click', function (ev) {
        nextSlide();
    });
    function nextSlide(goBackwards) {
        clearInterval(interval);
        interval = setInterval(nextSlide, 7000);
        var current = $('#image-holder .current');
        current.fadeOut(1500, function () {
            if (goBackwards) {
                current.toggleClass('current').prependTo('#container');
                $('#container').find('img').last().addClass('current').hide().appendTo('#image-holder').fadeIn(1500);
            } else {
                current.toggleClass('current').appendTo('#container');
                $('#container').find('img').first().addClass('current').hide().appendTo('#image-holder').fadeIn(1500);
            }


        });

    }




}