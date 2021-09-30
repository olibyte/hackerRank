function jumpingOnClouds(c) {
    // Write your code here
    //[0,1,0,0,0,1,0] =>
    //n:
    //j:+++
    var jumps = 0;
    var n = c.length-1;
    while (n !== 0) {
        if (c[n - 2] === 0) {
            n--;
        }
        jumps++;
        n--;
    }
    return jumps;
}