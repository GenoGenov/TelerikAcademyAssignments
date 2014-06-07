document.getElementById('setColorBtn').onclick=function(){
    var color = document.getElementsByName('colorPicker')[0].value;
    document.body.style.backgroundColor = color;
}