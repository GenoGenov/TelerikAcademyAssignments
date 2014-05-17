function isBiggerThanNeighbors(arr, index) {
    if (!Array.isArray(arr) || !parseInt(index) || index <= 0 || index >= arr.length) {
        return false;
    }

    return arr[index] > arr[index - 1] && arr[index] > arr[index + 1];
}

function getFirstBiggerThanNeighbors(arr) {
    if (!Array.isArray(arr)) {
        return -1;
    }

    for (var i = 1; i < arr.length - 1; i++) {
        if (isBiggerThanNeighbors(arr, i)) {
            return i;
        }
    }

    return -1;
}

function myfunction() {

}

var arr = [1, 2, 2, 3, 1, 4, 1, 6];

console.log(getFirstBiggerThanNeighbors(arr));