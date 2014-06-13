window.onload=function(){
    $('#prepend').on('click', function() {
        $('#start').before('<div>before div</div>');
    });

    $('#append').on('click', function () {
        $('#start').after('<div>after div</div>');
    });
}