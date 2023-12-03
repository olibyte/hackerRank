def checkMagazine(magazine, note):
    # Write your code here
    # if there aren't enough words in the magazine Harold can't write the note
    if len(magazine) < len(note):
        print('No')
    else:
        words = {}
        can_replicate = True
        # place magazine words into dictionary
        for m in magazine:
            if m not in words:
                words[m] = 1
            else:
                words[m] += 1
        # check if our note words are in the dictionary, and that there's enough of them
        for n in note:
            if n in words and words[n] >= 1:
                words[n] -= 1
            else:
                can_replicate = False
                break
        if can_replicate:
            print('Yes')
        else:
            print('No')
        # O(m+n) time, O(m) space
