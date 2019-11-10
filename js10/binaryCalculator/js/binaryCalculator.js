let btns = document.querySelectorAll('.button')
Array.prototype.forEach.call(btns, function addClickListener(btn) {
    btn.addEventListener('click', action);
});

var res = document.getElementById("res");
var resString = "";

function action(e) {
    var btn = e.target || e.srcElement;
    switch (btn.id) {
        case 'btn0':
            resString += 0;
            break;
        case 'btn1':
            resString += 1;
            break;
        case 'btnClr':
            resString = "";
            break;
        case 'btnEql':
            calculate();
            break;
        case 'btnSum':
            resString += '+';
            break;
        case 'btnSub':
            resString += '-';
            break;
        case 'btnMul':
            resString += '*';
            break;
        case 'btnDiv':
            resString += '/';
            break;
    }
    res.innerHTML = resString;
}

function calculate() {
    var re = /(\d+)(\D)(\d+)/;
    var rex = re.exec(resString);
    switch (rex[2]) {
        case '+':
            resString = addBinary(rex[1], rex[3]);
            break;
        case '-':
            let raw = subtractBinary(rex[1], rex[3]);
            resString = dropLeadingZeros(raw);
            break;
        case '*':
            resString = peasantMultiplication(rex[1], rex[3]);
            break;
        case '/':
            resString = binaryDivision(rex[1], rex[3]);
            break;
    }
}

// logic gates
function xor(a, b) {
    return a === b ? 0 : 1;
}

function and(a, b) {
    return a == 1 && b == 1 ? 1 : 0;
}

function or(a, b) {
    return a || b;
}

function not(a) {
    return a == 0 ? 1 : 0;
}

function halfSubtractor(a, b) {
    // using logical expression 
    // https://www.geeksforgeeks.org/digital-electronics-half-subtractor/
    const difference = xor(a, b);
    const borrow = and(not(a), b);
    return [difference, borrow];
}

function fullSubtractor(a, b, borrow) {
    // Fig 3.24 http://www.eeeguide.com/full-subtractor/
    const hs1 = halfSubtractor(a, b);
    const hs2 = halfSubtractor(hs1[0], borrow);
    return [hs2[0], or(hs2[1], hs1[1])];
}

function halfAdder(a, b) {
    // Fig 3.13 http://www.eeeguide.com/half-adder/
    const sum = xor(a, b);
    const carry = and(a, b);
    return [sum, carry];
}

function fullAdder(a, b, carry) {
    // Fig 3.18 http://www.eeeguide.com/full-adder/
    halfAdd = halfAdder(a, b);
    const sum = xor(carry, halfAdd[0]);
    carry = and(carry, halfAdd[0]);
    carry = or(carry, halfAdd[1]);
    return [sum, carry];
}

function padZeroes(a, b) {
    const lengthDifference = a.length - b.length;
    switch (lengthDifference) {
        case 0:
            break;
        default:
            const zeroes = Array.from(Array(Math.abs(lengthDifference)), () =>
                String(0)
            );
            if (lengthDifference > 0) {
                // if a is longer than b
                // then we pad b with zeroes
                b = `${zeroes.join('')}${b}`;
            } else {
                // if b is longer than a
                // then we pad a with zeroes
                a = `${zeroes.join('')}${a}`;
            }
    }
    return [a, b];
}

function addBinary(a, b) {
    let sum = '';
    let carry = '';

    const paddedInput = padZeroes(a, b);
    a = paddedInput[0];
    b = paddedInput[1];

    for (let i = a.length - 1; i >= 0; i--) {
        if (i == a.length - 1) {
            // half add the first pair
            const halfAdd1 = halfAdder(a[i], b[i]);
            sum = halfAdd1[0] + sum;
            carry = halfAdd1[1];
        } else {
            // full add the rest
            const fullAdd = fullAdder(a[i], b[i], carry);
            sum = fullAdd[0] + sum;
            carry = fullAdd[1];
        }
    }
    return carry ? carry + sum : sum;
}

function subtractBinary(a, b) {
    let diff = '';
    let borrow = '';

    const paddedInput = padZeroes(a, b);
    a = paddedInput[0];
    b = paddedInput[1];

    for (let i = a.length - 1; i >= 0; i--) {
        if (i == a.length - 1) {
            // half subtract the first pair
            const halfSub1 = halfSubtractor(a[i], b[i]);
            diff = halfSub1[0] + diff;
            borrow = halfSub1[1];
        } else {
            // full subtract the rest
            const fullSub = fullSubtractor(a[i], b[i], borrow);
            diff = fullSub[0] + diff;
            borrow = fullSub[1];
        }
    }
    // keep leading zeros for binary division
    return !borrow ? diff : twoComplement(diff);
}

function twoComplement(str) {
    let oc = ""; // get one's complement
    for(let i = 0; i < str.length; i++) {
        oc += not(str[i]);
    }
    // add one to one's complement
    return "-" + addBinary(oc, "1");
}

function peasantMultiplication(a, b) {
    let res = a[a.length - 1] ? b : 0; // initialize result
    a = a.slice(0, -1); // half first number
    while (a.length) {
        b += 0; // double second number
        if(a[a.length - 1] == 1) {
            // add second number to result when first number is odd
            res = addBinary(res, b);
        }
        a = a.slice(0, -1); // half first number
    }
    return res;
}

// shift and subtract algorithm
// https://courses.cs.vt.edu/~cs1104/Division/ShiftSubtract/Shift.Subtract.html
function binaryDivision(a, b) {
    let quo = "";
    a = dropLeadingZeros(a);
    b = dropLeadingZeros(b);
    let i = 0;
    let j = a.length - b.length;
    while (i <= j) {
        let s = section(a, i, i + b.length);
        if (dendOverSor(s[1], b)) {
            let diff = subtractBinary(s[1], b);
            quo += 1;
            a = assemble(s, diff);
        } else {
            quo += 0;
            a = assemble(s, s[1]);
        }
        i++;
    }

    return dropLeadingZeros(quo);
}

// section dividend
function section(a, i, e) {
    let s = [];
    s[0] = a.substring(0, i);
    s[1] = a.substring(i, e);
    s[2] = a.substring(e);
    return s;
}

// reassemble dividend
function assemble(s, diff) {
    return s[0] + diff + s[2];
}

// test if (diviDEND >= diviSOR) only digits above divisor. Both are left aligned.
function dendOverSor(dend, sor) {
    for (let i = 0; i < sor.length; i++) {
        if(dend[i] == 0 && sor[i] == 1) {
            // diviSOR is greater than diviDEND
            return false;
        }
    }
    return true;
}

function dropLeadingZeros(str) {
    let i = 0;
    while (str[i] == 0) {
        i++;
    }
    if (i == str.length) {
        return "0";
    }
    return str.substring(i, str.length);
}