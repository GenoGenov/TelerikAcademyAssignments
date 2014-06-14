window.onload = function () {
    (function ($) {
        $.fn.messageBox = function () {
            var $this = $(this);

            $this.append($('<div/>').addClass('messages-success'))
                 .append($('<div/>').addClass('messages-error'));

            return $this;
        }
    }(jQuery));

    (function ($) {
        $.fn.error = function (errorMsg) {
            var $this = $(this);

            var span = $('<span>').addClass('error-message').html(errorMsg).css({
                display: 'inline-block',
                opacity: '0'
            });

            $this.find('.messages-error').append(span.animate({
                opacity: '1'
            }, 1000, function () {
                setTimeout(function () {
                    span.hide();
                }, 3000);
            }));

            return $this;
        }
    }(jQuery));

    (function ($) {
        $.fn.success = function (successMsg) {
            var $this = $(this);

            var span = $('<span>').addClass('success-message').html(successMsg).css({
                display: 'inline-block',
                opacity: '0'
            });

            $this.find('.messages-success').append(span.animate({
                opacity: '1'
            }, 1000, function () {
                setTimeout(function () {
                    span.hide();
                }, 3000);
            }));

            return $this;
        }
    }(jQuery));

    var box = $('#message-box').messageBox();
    box.error('Sorry :/');
    setTimeout(function(){
        box.success('Congratz!')
    },2000);
    
}