def twoStrings(s1, s2):
    # Write your code here
        s1_substrings = set(s1)
        s2_substrings = set(s2)
        
        common_substrings = s1_substrings.intersection(s2_substrings)
        if common_substrings:
            return 'YES'
        else:
            return 'NO'
        # O(n) space, O(n) time