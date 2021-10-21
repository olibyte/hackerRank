function maximumToys(prices, k) {
    var sortedPrices = prices.sort((a,b) => { return a - b });
    var toyCount = 0;
    // console.log(`Sorted array: ${sortedPrices}`);
    for (let i = 0; i < sortedPrices.length; i++) {
        if (sortedPrices[i] <= k) {
            k -= sortedPrices[i];
            toyCount++;
        }
    }
    return toyCount;
}