function minMaxProperties(obj) {
    var objProps = [];
    for (var i in obj) {
        objProps.push(i);
    }

    var propsSorted = objProps.sort();
    console.log(arguments[0] + ':');
    console.log('Min: ' + propsSorted[0]);
    console.log('Max: ' + propsSorted[propsSorted.length - 1]);
}
minMaxProperties(document);
minMaxProperties(window);
minMaxProperties(navigator);