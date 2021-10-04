function rotLeft(a, d) {
    var n = a.length;
    const b = new Array();
    for (let i = 0; i < n - d; i++) {
        b[i] = a[i + d];
    }
    for (let i = 0; n - d + i < n; i++) {
        b[n - d + i] = a[i]
    }
    return b;
}