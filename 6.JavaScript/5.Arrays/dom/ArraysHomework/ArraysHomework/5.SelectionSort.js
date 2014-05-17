var arr = [3, 2, 3, 4, 2, 2, 4, 4, 2, 8, 1, 845, 34, 6, 7, 4, 3, 7, 0, , 2, 2, 444363463463];

function selectionSort(arr) {
    arr.map(Number);
    for (var i = 0; i < arr.length - 1; i++) {
        var min = i;
        for (var j = i + 1; j < arr.length; j++) {
            if (arr[j] < arr[min]) {
                min = j;
            }
        }
        if (min !== i) {
            var swap = arr[i];
            arr[i] = arr[min];
            arr[min] = swap;
        }
    }
    return arr;
}

console.log( selectionSort(arr));