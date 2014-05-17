var str = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et luctus nunc, eu lobortis ligula. Curabitur tristique ipsum et euismod vestibulum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla in rutrum massa, at feugiat eros. Suspendisse luctus consequat dictum. Donec adipiscing viverra venenatis. Duis sit amet nisl risus. Fusce interdum ligula ante, vel ullamcorper metus blandit id. Aenean vulputate sollicitudin auctor. Sed in mauris at libero vulputate mollis. Etiam vel odio amet in dolor dictum AMET mattis. Etiam ultricies cursus ante ac molestie. Aenean hendrerit non lectus non porttitor. Pellentesque tincidunt aliquam libero sit amet elementum. Ut ut ligula et turpis consectetur fermentum. Phasellus dolor lacus, blandit eget rhoncus sed, pharetra eget neque.';

function findWordsCount(text, word, caseSence) {
    var regExp;
    caseSence = caseSence !== false;
    if (caseSence) {
        regExp = new RegExp('(\\W|^)' + word + '(\\W|$)', 'g');
        return text.match(regExp).length;
    }

    regExp = new RegExp('(\\W|^)' + word + '(\\W|$)', 'gi');
    return text.match(regExp).length;
}

console.log(findWordsCount(str, 'amet', false));
console.log(findWordsCount(str, 'amet'));