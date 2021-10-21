function isValid(s) {
    if (s.length === 0) { return 'YES' }
    const freq = {};
    for (let i = 0; i < s.length; ++i) {
        if (!freq[s[i]]) { freq[s[i]] = 0 }
        freq[s[i]]++;
    }
    const freqfreq = {};
    for (let c of Object.keys(freq)) {
        const f = freq[c];
        if (!freqfreq[f]) { freqfreq[f] = 0 }
        freqfreq[f]++;
    }
    let freqs = Object.keys(freqfreq);
    if (freqs.length === 1) { return 'YES' }
    if (freqs.length > 2) { return 'NO' }
    let [freq1, freq2] = freqs.map(f => ({ val: parseInt(f), freq: freqfreq[f] }));
    if (freq1.val > freq2.val) {
        [freq1, freq2] = [freq2, freq1];
    }
    return (freq1.val === 1 && freq1.freq === 1) || (freq2.freq === 1 && freq2.val - 1 === freq1.val) ? 'YES' : 'NO';
}