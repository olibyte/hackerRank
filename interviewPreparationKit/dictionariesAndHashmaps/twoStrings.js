function twoStrings(s1, s2) {
    // Write your code here
    var set1 = new Set();
    var set2 = new Set();
    for (let i = 0; i < s1.length; i++) {
        set1.add(s1[i]);
    }
    for (let i = 0; i < s2.length; i++) {
        set2.add(s2[i]);
    }
    var intersection = new Set(
        [...set1].filter(x => set2.has(x))
    );
    return intersection.size > 0 ? 'YES' : 'NO';
}