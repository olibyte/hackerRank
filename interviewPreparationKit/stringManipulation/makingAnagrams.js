function makeAnagram(a, b) {
    let charFreqMap = new Map();
    let total = 0;
    //chuck chars of a into map
    Array.from(a).forEach(char => {
        charFreqMap[char] = charFreqMap[char] || 0;
        charFreqMap[char]++;
    })
    //chuck chars of b into map
    Array.from(b).forEach(char => {
        charFreqMap[char] = charFreqMap[char] || 0;
        charFreqMap[char]--;
    })
    //
    Object.keys(charFreqMap).forEach(k => {
        if (charFreqMap[k] !== 0) {
            total += Math.abs(charFreqMap[k]);
        }
    })
    return total;
}