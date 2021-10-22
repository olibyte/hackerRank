function freqQuery(queries) {
    const result = [];
    const hash = {}; //map of elements and their frequencies. 
    const freq = []; //array of frequencies

    //i.e. queries[i] = (1,3) => hash => 3,1. freq[1] = 1.
    //i.e. queries[i] = (1,5) => hash => {[3,1],[5,1]}. freq[1] = 2. i.e. there are 2 vals that occur 1 times
    //i.e. queries[i] = (1,3) => hash => 3,1. freq = [1,1]. freq[2] = 1. freq[1] = 1. there is 1 val that occurs 1 times, 1 val that occurs 2 times.
    

    for (let i = 0; i < queries.length; i++) {
        const [operation, value] = queries[i];
        const initValue = hash[value] || 0; //to set values in our hashmap. set to 0 if no entry, otherwise increment by 1.

        if (operation === 1) {//INSERT value into hashmap
            hash[value] = initValue + 1;

            freq[initValue] = (freq[initValue || 0]) - 1;
            freq[initValue + 1] = (freq[initValue + 1] || 0) + 1;
        }
        else if (operation === 2 && initValue > 0) { //REMOVE (if value is present)
            hash[value] = initValue - 1;

            freq[initValue - 1] += 1;
            freq[initValue] -= 1;
        }
        else if (operation === 3) {
            result.push(freq[value] > 0 ? 1 : 0);
        }
    }
    return result;
};