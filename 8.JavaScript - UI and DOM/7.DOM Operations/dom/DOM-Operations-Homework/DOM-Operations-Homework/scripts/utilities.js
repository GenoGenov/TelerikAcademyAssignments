function getRandomValueInRange(min, max) {
    var random = Math.floor(Math.random() * (max - min + 1));
    return random;
}

function getRandomColor(transparentPossible) {
    return 'rgba(' + getRandomValueInRange(0, 255) + ',' + getRandomValueInRange(0, 255) + ',' + getRandomValueInRange(0, 255) + ',' + (transparentPossible ? getRandomValueInRange(5, 10) / 10 : 1);
}