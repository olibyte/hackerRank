'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', function(inputStdin) {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.split('\n');

    main();
});

function readLine() {
    return inputString[currentLine++];
}

/*
 * Complete the 'countingValleys' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts following parameters:
 *  1. INTEGER steps
 *  2. STRING path
 */
//UDDDUDUU => 1
//DDUUUUDD => 
function countingValleys(steps, path) {
    // Write your code here
    var valleyCount = 0;
    var level = 0;
    var chars = path.split('');
    for (let i = 0; i < chars.length; i++) {
        if (chars[i] === 'D') {
            level--;
        } else {
            level++;
            if (level === 0) {
                valleyCount++;
            }
        }
    }
    return valleyCount;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const steps = parseInt(readLine().trim(), 10);

    const path = readLine();

    const result = countingValleys(steps, path);

    ws.write(result + '\n');

    ws.end();
}
