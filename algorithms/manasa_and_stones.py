#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the stones function below.
def stones(n, a, b):
    if a == b: #edge case, no dif
        return [(n - 1) * a] #return series of stones
    # can perform this check to ensure the list of stones is sorted asc
    #alternatively, we could just call omit these lines and sort the stones list at the last step
    if a > b: 
        a, b = b, a

    stones = []
    for i in range(0,n):
        stone = ((n - 1 - i) * a) + (i * b)
        stones.append(stone)
    return stones
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    T = int(input())

    for T_itr in range(T):
        n = int(input())

        a = int(input())

        b = int(input())

        result = stones(n, a, b)

        fptr.write(' '.join(map(str, result)))
        fptr.write('\n')

    fptr.close()
