function minimumBribes(q) {
    // Write your code here
    var bribeCount = 0;
    var tooChaotic = false;
    for (let i = 0; i < q.length; i++) {
        if (q[i] - (i + 1) > 2) { //if someone's skipped more than 2 places
            tooChaotic = true;
            break;
        }
        for (let j = Math.max(0, q[i] - 2); j < i; j++) { //loop to count the number of bribes q[i] - 2 this candidate has made. if negative, they've made less bribes than they've accepted. if 0, they've accepted no bribes.
            if (q[j] > q[i]) {
                bribeCount++;
            }
        }
    }
    tooChaotic ? console.log(`Too chaotic`) : console.log(`${bribeCount}`);
}