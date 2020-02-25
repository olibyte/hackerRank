# Input:
#  a: The first non-negative integer in string. Example: "123"
#  b: The second non-negative integer in string. Example: "3344"
# Returns:
#  True if a is larger than b.
#  False if a is smaller than or equal to b.

#no casting to int!
def larger_than(a, b):
    #a = "1232" b = "202"
    if (len(a) == len(b)): #if they have the same number of digits...
        if a > b:
            return True
        else:
            return False 
    elif(len(a) > len(b)): #if a has more digits...
        return True
    else: #b has more digits
        return False

#only compare single digits
def larger_than(a, b):
    if len(a) > len(b):
        return True
    elif len(a) == len(b):
        for i in range(len(a)):
            if a[i] < b[i]:
                return False
            return True
    return False

#cast to int
def larger_than(a, b):
    if (int(a) > int(b)):
        return True
    return False

#their solution
def larger_than(a, b):
    if len(a) > len(b): # a = "222" b = "99"
        return True
    elif len(a) < len(b):
        return False
    
    #a = 223 b = "222"
    for i in range(len(a)):
        if a[i] == b[i]:
            continue
        elif a[i] > b[i]:
            return True
        else: #a[i] < b[i]
            return False
    return False #the two strings are equivalent