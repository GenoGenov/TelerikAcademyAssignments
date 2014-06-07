//using query selector

function getDivDirectNodesQuery() {
    var directDivChildren = document.querySelectorAll('div>div');
    for (var i = 0, len = directDivChildren.length; i < len; i++) {
        directDivChildren[i].className+=' border';
    }
}

//using tag name selector

function getDivDirectNodesByTag() {
    var divs = document.getElementsByTagName('div');
    for (var i = 0, length = divs.length; i < length; i++) {
        if (divs[i].parentNode.tagName.toLowerCase() === 'div') {
            divs[i].className+=' border';
        }
    }
}

//getDivDirectNodesQuery();
getDivDirectNodesByTag();