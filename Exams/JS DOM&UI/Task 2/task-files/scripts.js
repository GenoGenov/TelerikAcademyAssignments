$.fn.gallery = function (options) {
    $this = $(this);

    options = options || 4;

    $this.css({
        width: parseInt(options) * 270 + 'px'
    });

    $this.addClass('gallery');
    var selected = $this.find('.selected').addClass('clearfix').html('');

    $this.find('.image-container').on('click', function () {
        if (selected.html() === '') {

            var $this = $(this);
            var $nextImg,
                $prevImg;

            $this.parent().addClass('blurred').addClass('disabled-background');

            var $current = $('<div/>')
                .addClass('current-image')
                .append($('<img/>')
                    .attr('src', $this.find('img').attr('src'))
                    .attr('id', 'current-image')).on('click', function () {
                        selected.html('');
                        $this.parent().removeClass('blurred').removeClass('disabled-background');
                    });

            if ($this.prev().length) {
                $prevImg = $('<img/>')
                  .attr('src', $this.prev().find('img').attr('src'))
                  .attr('id', 'previous-image');
            } else {
                $prevImg = $('<img/>')
                  .attr('src', $this.parent().find('img').last().attr('src'))
                  .attr('id', 'previous-image');
            }


            if ($this.next().length) {
                $nextImg = $('<img/>')
                  .attr('src', $this.next().find('img').attr('src'))
                  .attr('id', 'next-image');
            } else {
                $nextImg = $('<img/>')
                  .attr('src', $this.parent().find('img').first().attr('src'))
                  .attr('id', 'next-image');
            }


            var $previous = $('<div/>')
               .addClass('previous-image')
               .append($prevImg).on('click', function () {
                   selected.html('');
                   if ($this.prev().length) {
                       $this.prev().click();
                   } else {
                       $this.parent().find('.image-container').last().click();
                   }

               });

            var $next = $('<div/>')
              .addClass('next-image')
              .append($nextImg).on('click', function () {
                  selected.html('');
                  if ($this.next().length) {
                      $this.next().click();
                  } else {
                      $this.parent().find('.image-container').first().click();
                  }

              });

            selected.append($previous);
            selected.append($current);
            selected.append($next);
        }
    });
};