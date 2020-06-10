
def union(L1,L2):
    #base case
    if L1 == []:
        return L2
    else:
        L = union(L1[1:],L2)
        #if candidate is in L
        if L1[0] in L:
            return L
        else:
            return ([L1[0]] + L)

def intersect(L1,L2):
    #base case => if L1 is empty list no intersection / reached the base step
    if L1 == []:
        return []
    else:
        L = intersect(L1[1:],L2)
        if L1[0] in L2:
            if L1[0] not in L:
                L.append(L1[0])
    return L

def diff(L1,L2):
    #base case => if L1 is empty list we've reached the base step
    if L1 == []:
        return []
    else:
        L = diff(L1[1:],L2)
        # if candidate is not in L2
        if L1[0] not in L2:
            #and not already in our difference list
            if L1[0] not in L:
                L.append(L1[0])

def countEven(L1):
    #base case => if list is empty, there are 0 even elements
    if L1 == []:
        return 0
    else:
        x = countEven(L1[1:])
        #if candidate is even
        if L1[0] % 2 == 0:
            x+=1
    return x