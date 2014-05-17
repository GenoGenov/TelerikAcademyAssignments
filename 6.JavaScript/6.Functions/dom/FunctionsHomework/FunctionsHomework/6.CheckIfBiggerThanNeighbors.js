function isBiggerThanNeighbors(arr, index) {
    if (!Array.isArray(arr) || !parseInt(index) || index<=0 || index>=arr.length) {
        return -1;
    }

    return arr[index] > arr[index - 1] && arr[index] > arr[index + 1];
}

console.log(isBiggerThanNeighbors([1, 2, 3, 3, 3, 4, 1, 6], 5));