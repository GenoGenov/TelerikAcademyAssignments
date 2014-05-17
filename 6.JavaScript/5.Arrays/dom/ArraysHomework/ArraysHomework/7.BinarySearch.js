function binarySearch(arr, element) {
    var minIndex = 0;
    var maxIndex = arr.length - 1;
    var currentIndex;
    var currentElement;

    while (minIndex <= maxIndex) {
        currentIndex = (minIndex + maxIndex) / 2 | 0; //instead of Math.floor, its faster(I think..)
        currentElement = arr[currentIndex];

        if (currentElement < element) {
            minIndex = currentIndex + 1;
        } else if (currentElement > element) {
            maxIndex = currentIndex - 1;
        } else {
            return currentIndex;
        }
    }

    return -1;
}

var arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

console.log(binarySearch(arr,9));