function repeatedString(s, n) {
    // Write your code here
    var repeat = Math.floor(n / s.length);
    var remainder = (n % s.length);
    console.log(`
    n: ${n}
    s.length: ${s.length}
    remainder: ${remainder}
    repeat: ${repeat}
    `)
    var subStringCount = 0;
    for (let i = 0; i < s.length; i++) {
        if (s.charAt(i) === 'a') {
            subStringCount++;
        }
    }
    console.log(`subStringCount: ${subStringCount}`)
    subStringCount = subStringCount * repeat;
    for (let i = 0; i < remainder; i++) {
        if (s.charAt(i) === 'a') {
            subStringCount++;
        }
    }
    return subStringCount;
}