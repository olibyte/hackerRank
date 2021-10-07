function minimumSwaps(arr) {
    if (arr.length < 2) return 0;

    var minimumSwaps = 0;
    var index = 0;
    while (index < arr.length) {
        if (arr[index] === index + 1) {
            index++;
            continue;
        }
        swap(arr, index, (arr[index] - 1));
        minimumSwaps++;
    }
    return minimumSwaps;
}
function swap(arr, leftIndex, rightIndex) {
    let temp = arr[leftIndex];
    arr[leftIndex] = arr[rightIndex];
    arr[rightIndex] = temp;
}