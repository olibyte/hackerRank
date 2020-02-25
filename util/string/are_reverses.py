def are_reverses(string_1, string_2):
    string_1_rev = ''.join(reversed(string_1))
    string_2_rev = ''.join(reversed(string_2))
    if((string_1_rev == string_2) & (string_2_rev == string_1)):
        return True
    else:
        return False
#faster using extended slice
def are_reverses(string_1, string_2):
    string_1_rev = string_1[::-1]
    string_2_rev = string_2[::-1]
    if((string_1_rev == string_2) & (string_2_rev == string_1)):
            return True
    else:
        return False

#another naive implementation, iterating forwards through each char of string_1 and comparing against backwards interation through string_2
#string_1[first_element] must equal string_2[last_element], string_1[first_element+1] must equal string_2[last_element-1]
def are_reverses(string_1, string_2):
    for i in range(len(string_1)):
        i_2 = len(string_2) - i - 1
        if string_1[i] != string_2[i_2]:
            return False
    return True