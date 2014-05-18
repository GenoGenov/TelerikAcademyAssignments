function insertURL(input) {
    var result = '';
    while(input.indexOf('<a href')>-1 || input.indexOf('</a>')>-1){
        input = input.replace('<a href="', '[URL=');
        input = input.replace('">', ']');
        input = input.replace('</a>', '[/URL]');
    }
    return input;
}

var str = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

console.log(insertURL(str));