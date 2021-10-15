function sherlockAndAnagrams(s) {
    const map = {};
    for (let i = 0; i < s.length; i++) {
      let subset = [];
      for (let j = i; j < s.length; j++) {
        subset = [...subset, s[j]].sort().join("");
        map[subset] = ++map[subset] || 1;
      }
    }
  
    let anagrams = 0;
    Object.values(map).forEach((val) => {
      anagrams += (val * (val - 1)) / 2;
    });
  
    return anagrams;
  }
