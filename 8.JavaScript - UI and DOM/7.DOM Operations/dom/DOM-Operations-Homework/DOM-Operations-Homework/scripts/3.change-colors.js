window.onload = function () {

    var text = document.getElementById('text');

    document.getElementById('back-color').addEventListener('change', function () {
        text.style.backgroundColor = this.value;
    });

    document.getElementById('font-color').addEventListener('change', function () {
        text.style.color = this.value;
    });
}