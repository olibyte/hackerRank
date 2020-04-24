#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the sockMerchant function below.
def sockMerchant(n, ar):
    candidates = [] #list to keep track of sock
    pairs = 0
    for sock in ar:
        if sock in candidates: #if we already have a sock in our candidates list
            candidates.remove(sock) #remove it and increase the count of pairs
            pairs += 1
        else:
            candidates.append(sock) #add it to our list

    return pairs
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())

    ar = list(map(int, input().rstrip().split()))

    result = sockMerchant(n, ar)

    fptr.write(str(result) + '\n')

    fptr.close()
