(function () {
    var domModule = (function () {
        var buffer = {};

        function appendChild(node, selector) {
            var element = document.querySelector(selector);
            element.appendChild(node);
        }

        function removeChild(parentSelector, nodeToRemoveSelector) {
            var parent = document.querySelector(parentSelector);
            var childToRemove = parent.querySelector(nodeToRemoveSelector);
            parent.removeChild(childToRemove);
        }

        function addHandler(selector, eventType, callback) {
            var element = document.querySelector(selector);
            element.addEventListener(eventType, callback);
        }
       
        function appendToBuffer(selector, node) {
            var element = document.querySelector(selector);
            if (buffer.hasOwnProperty(selector)) {
                if (buffer[selector].fragment.childElementCount === 99) {
                    var frag = buffer[selector].fragment;
                    frag.appendChild(node);
                    element.appendChild(frag);
                    buffer[selector].fragment = document.createDocumentFragment();
                } else {
                    buffer[selector].fragment.appendChild(node);
                }
            } else {
                var newFrag = document.createDocumentFragment();
                newFrag.appendChild(node);
                buffer[selector] = {
                    fragment: newFrag
                }
            }
        }

        function getElement(selector) {
            return document.querySelector(selector);
        }

        return {
            appendChild: appendChild,
            removeChild: removeChild,
            addHandler: addHandler,
            appendToBuffer: appendToBuffer
        };

    })();

    var div = document.createElement("div");
    //appends div to #wrapper
    domModule.appendChild(div, "#wrapper");
    //removes li:first-child from ul
    domModule.removeChild("ul", "li:first-child");
    //add handler to each a element with class button
    domModule.addHandler("a.button", 'click',
                         function () { alert("Clicked") });
    for (var i = 0; i < 100; i++) {
        domModule.appendToBuffer("#container", div.cloneNode(true));
    }

    var navItem = document.createElement('li');
    navItem.innerHTML = 'Nav Item';

    for (i = 0; i < 100; i++) {
        domModule.appendToBuffer("#main-nav ul", navItem.cloneNode(true));
    }
   

}())