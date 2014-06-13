window.onload=function(){
    $('#color-changer').on('change',function(){
        var value = this.value;
        $('body').css('background-color', value);
    })
}