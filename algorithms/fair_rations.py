#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the fairRations function below.
def fairRations(B):
    if sum(B) % 2 != 0:
        return 'NO'
    loaves = 0
    for i in range(len(B)):
        if B[i] % 2 != 0:  
            B[i] = B[i] + 1
            B[i + 1] = B[i + 1] + 1
            loaves = loaves + 2
    return loaves
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    N = int(input())

    B = list(map(int, input().rstrip().split()))

    result = fairRations(B)

    fptr.write(str(result) + '\n')

    fptr.close()
