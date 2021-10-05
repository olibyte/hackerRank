function hourglassSum(arr) {
    //initialize our counters given the constraint arr[i] >= -9
    var best = -999;
    var total = -999;
    for (let i = 0; i < arr.length-2; i++) {
        for (let j = 0; j < arr[i].length-2; j++) {
            total = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
             arr[i + 1][j + 1]
            + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                console.log(`best: ${best}, total: ${total}`);
            if (total > best) {
                best = total;
            }
        }
    }
    return best;
}