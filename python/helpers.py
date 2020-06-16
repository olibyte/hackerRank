# computes set of elements present in 2 lists
import random
from scipy._lib.six import xrange

def union(L1,L2):
    #base case => if L1 is empty the union is simply the elements present in L2
    if L1 == []:
        return L2
    else:
        L = union(L1[1:],L2)
        #if candidate is in L
        if L1[0] in L:
            return L
        else:
            return ([L1[0]] + L)
#computes set of elements common to 2 given lists
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
#computes set of elements that are not common to 2 given lists i.e. all elements in L1 that are not in L2
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
    return L
# computes number of even elements in a list
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
list_a = random.sample(range(0,20),10)
list_b = random.sample(range(0,20),10)

# list_a = [1,2,3]
# list_b = [1,2,3,4,5]
# print(list_a,list_b)
# print(union(list_a,list_b))
# print(diff(list_a,list_b))
# print(intersect(list_a,list_b))
# print(countEven(list_a))

# P(A) = 13/52 = 1/4
# P(B) = 12/51 = 12/51
# P(A) & P(B) = 12/204

# print(204//12,204%12)
# P(B|A) = P(A&B) / P(A)
# P(A&B) = P(A) * P(B)
# P(A) = 3/7
# P(B) = 4/6
