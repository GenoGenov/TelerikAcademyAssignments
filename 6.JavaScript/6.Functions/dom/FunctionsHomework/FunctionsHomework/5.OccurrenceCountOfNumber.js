function getOccurrenceCount(arr, num) {
    if (!Array.isArray(arr) || !parseInt(num)) {
        return -1;
    }

    return arr.filter(function (a) {
        return a === num;
    }).length;
}

console.log( getOccurrenceCount([1, 2, 3, 3, 3, 4, 5, 6], 3));