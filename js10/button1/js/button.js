var btn = document.getElementById('btn');

var counter = 0;
btn.onclick = function() {
counter++
/* This changes the button's label */
btn.innerHTML = `${counter}`;
};