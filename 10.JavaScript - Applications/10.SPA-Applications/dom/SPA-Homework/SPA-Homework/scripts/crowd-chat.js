(function ($) {

    var $errorMsg = $('<div/>').addClass('error').appendTo('body').hide();
    var url = 'http://crowd-chat.herokuapp.com/posts';
    var reloadMessages= function() {
        $.getJSON(url).then(function(data) {
            $.each(data, function(key, item) {
                $('<div/>').addClass('message').attr('id', item.id)
                    .append($('<strong/>').addClass('message-author').text(item.by))
                    .append($('<p/>').addClass('message-text').html(item.text))
                    .appendTo($('#messages'));
                $('#messages').append($('<br/>'));
            });
            $('#messages').scrollTop($('#messages').prop("scrollHeight"));
        });
    };

    var app = $.sammy('#app-main', function () {
        this.use('Template');
        var user = false;
      

        this.get('#/home', function(context) {
            this.$element().on('click', '#join', function () {
                context.redirect('#/chat');
            });
            this.partial('/partials/home.html');

           

        });

        this.get('#/chat', function(context) {
            if (user) {
                this.partial('/partials/chat.html');

                reloadMessages();
                setInterval(reloadMessages, 3000);

                this.$element().on('click','#send-btn', function (ev) {
                    var message = $(this).parent().find('#write-msg').val();
                    if (message.length === 0) {
                        $errorMsg.html('The message must be atleast 1 symbol long!')
                            .appendTo($('#send')).show().fadeOut(1500);
                        return;
                    } else {
                        $.post(url, { user: user, text: message }).then(reloadMessages);
                    }
                });
            } else {
                context.redirect('#/login');
            }
        });

        this.get('#/login',function(context) {
            this.partial('/partials/login.html');
            this.$element().on('click', '#submit', function (ev) {
                var username = $('#username').val();
                if (username.length < 3) {
                    $errorMsg.html('Username must be atleast 3 symbols long!').show().fadeOut(1500);
                    return false;

                } else {
                    user = username;
                    context.redirect('#/chat');
                }
            });
        })

        $(function () {
            
            app.run('#/home');
        });
    });

})(jQuery);