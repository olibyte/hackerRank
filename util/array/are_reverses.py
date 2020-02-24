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