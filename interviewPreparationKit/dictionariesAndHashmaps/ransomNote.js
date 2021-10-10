function checkMagazine(magazine, note) {
    
    var magazineMap = new Map();
    var flag = false; //flag for noteWords not in magazineWords
    //store magazine words in map
    for (let i = 0; i < magazine.length; i++) {
        if (magazineMap.has(magazine[i]) !== true ) {
        magazineMap.set(magazine[i], 1);
        } else {
            magazineMap.set(magazine[i], (magazineMap.get(magazine[i])) + 1);
        }
    }
    for (let i = 0; i < note.length; i++) {
        //if note[i] is not in the map
        if (magazineMap.has(note[i] !== true)) {
            magazineMap.set(note[i], - 1);
        } else {
            magazineMap.set(note[i], (magazineMap.get(note[i])) - 1)
        }
    }
    // console.log(magazineMap);
    for (let v of magazineMap.values()) {
        if (v >= 0 !== true) { //if the noteword is not in the magazine, or we've used up all the notewords that were already present magazine
            flag = true;
        }
    }
    flag ? console.log('No') : console.log('Yes');
    
}