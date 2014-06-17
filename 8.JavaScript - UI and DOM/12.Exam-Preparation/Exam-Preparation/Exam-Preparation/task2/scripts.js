$.fn.tabs = function () {
    $this = $(this);

    $this.addClass('tabs-container').find('.tab-item-content').css({
        display:'none'
    });
    var $current = $this.find('.tab-item:first-of-type');

    $current.addClass('current').find('.tab-item-content').css({
        display:''
    });

    $this.on('click', '.tab-item-title', function () {
        $current.removeClass('current').find('.tab-item-content').css({
            display: 'none'
        });
        $current = $(this).parent().addClass('current').find('.tab-item-content').css({
            display: ''
        }).parent();
    });
};