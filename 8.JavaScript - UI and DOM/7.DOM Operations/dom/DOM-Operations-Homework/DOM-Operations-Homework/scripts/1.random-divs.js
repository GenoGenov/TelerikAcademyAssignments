
window.onload = function () {
    function generateRandomDivs() {
        var divsCount = getRandomValueInRange(7, 30);
        var div = document.createElement('div');
        var frag = document.createDocumentFragment();
        var strong = document.createElement('strong');
        strong.innerHTML = 'div';
        for (var i = 0; i < divsCount; i++) {
            div.style.width = getRandomValueInRange(20, 350) + 'px';
            div.style.height = getRandomValueInRange(20, 350) + 'px';
            div.style.backgroundColor = getRandomColor(true);
            div.style.color = getRandomColor();
            div.style.position = 'absolute';
            div.style.top = getRandomValueInRange(0, window.innerHeight - div.getAttribute('height') - 5) + 'px';
            div.style.left = getRandomValueInRange(0, window.innerWidth - div.getAttribute('width') - 5) + 'px';
            div.style.borderWidth = getRandomValueInRange(1, 20) + 'px';
            div.style.borderRadius = getRandomValueInRange(1, 50) + 'px';
            div.style.borderColor = getRandomColor();
            div.style.borderStyle = 'solid';
            div.appendChild(strong);
            frag.appendChild(div.cloneNode(true));
        }
        document.body.appendChild(frag);
    }

    generateRandomDivs();
}
