#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the chocolateFeast function below.
def chocolateFeast(n, c, m):
    result = 0
    bars = int(n/c)
    result += bars
    wrappers = bars
    while wrappers >= m:
        bars = int(wrappers / m)
        wrappers = wrappers % m
        wrappers += bars
        result += bars
    return result

    #bit more elegant doing it in the one step
    # chocs = n / c
    # wraps = chocs
    # while wraps >= m:
    #     chocs += wraps/m
    #     wraps = wraps/m + wraps%m
    # return chocs

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    t = int(input())

    for t_itr in range(t):
        ncm = input().split()

        n = int(ncm[0])

        c = int(ncm[1])

        m = int(ncm[2])

        result = chocolateFeast(n, c, m)

        fptr.write(str(result) + '\n')

    fptr.close()