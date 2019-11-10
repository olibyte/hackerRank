let btn5 = document.querySelector('#btn5');
let numbersArray = [1, 2, 3, 6, 9, 8, 7, 4];

btn5.addEventListener('click', function () {
    numbersArray.unshift(numbersArray.pop());
    document.querySelector('#btn1').innerHTML = numbersArray[0];
    document.querySelector('#btn2').innerHTML = numbersArray[1];
    document.querySelector('#btn3').innerHTML = numbersArray[2];
    document.querySelector('#btn6').innerHTML = numbersArray[3];
    document.querySelector('#btn9').innerHTML = numbersArray[4];
    document.querySelector('#btn8').innerHTML = numbersArray[5];
    document.querySelector('#btn7').innerHTML = numbersArray[6];
    document.querySelector('#btn4').innerHTML = numbersArray[7];
});