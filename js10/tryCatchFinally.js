'use strict';

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', inputStdin => {
    inputString += inputStdin;
});

process.stdin.on('end', _ => {
    inputString = inputString.trim().split('\n').map(string => {
        return string.trim();
    });
    
    main();    
});

function readLine() {
    return inputString[currentLine++];
}

/*
 * Complete the reverseString function
 * Use console.log() to print to stdout.
 */
function reverseString(s) {
    try {
        //Try to reverse string s using the split, reverse, and join methods.
        console.log(s.split("").reverse().join(""));

    }
    catch (s) {
    //If an exception is thrown, catch it and print the contents of the exception's message on a new line.
        console.log(s.message);
    }
    finally {
       //print s on a new line. If no exception was thrown, then this should be the reversed string; if an exception was thrown, this should be the original string
        if(typeof s !== 'string'){
        
        var newString = String(s);
        
        console.log(newString);
        }
    }
}


function main() {
    const s = eval(readLine());
    
    reverseString(s);
}