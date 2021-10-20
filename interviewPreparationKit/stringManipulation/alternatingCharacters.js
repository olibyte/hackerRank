function alternatingCharacters(s) {
    // Write your code here
    var total = 0;
    for (let i = 0; i < s.length -1 ; i++) {
        if (s.charAt(i) == s.charAt(i+1)) {
            total++;
        }
    }
    return total;
}