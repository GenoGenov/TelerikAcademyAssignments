document.getElementById('getValBtn').onclick = function () {
    var inputValue = document.getElementById('input').value;
    if (inputValue) {
        document.getElementById('result').innerText = 'The value is ' + '"' + inputValue + '"';
    } else {
        document.getElementById('result').innerText = 'The input value is empty!';
    }
};