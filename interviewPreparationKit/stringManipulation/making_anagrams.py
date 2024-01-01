def makeAnagram(a, b):
    # Write your code here
    # 2 dicts to store character counts
    dict_a = {}
    dict_b = {}
    for char in a:
        # if dict
        if char not in dict_a: 
            dict_a[char] = 1
        else:
            dict_a[char] += 1
    for char in b:
        if char not in dict_b:
            dict_b[char] = 1
        else:
            dict_b[char] += 1
    dels = 0
    # number of deletions required is absolute dif between the 2 keys
    for key in dict_a:
        if key in dict_b:
            dels += abs(dict_a[key] - dict_b[key])
        else:
            dels += dict_a[key] # handle the case where char is not in string b
        print(dels)
    for key in dict_b:
        if key not in dict_a: # already taken care of dict_a keys, just need to find chars in b that aren't in string a
            dels += dict_b[key]
    return dels