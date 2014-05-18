function substrCount(text, stringToFind, ignoreCase) {

    if (ignoreCase) {
        text = text.toUpperCase();
        stringToFind = stringToFind.toUpperCase();
    }

    var count = 0;
    var index = text.indexOf(stringToFind, 0);

    while (index != -1) {
        count++;
        index = text.indexOf(stringToFind, index + 1);
    }

    return count;
}

var str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

console.log(substrCount(str,'in',true));