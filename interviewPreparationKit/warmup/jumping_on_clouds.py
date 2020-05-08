#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the jumpingOnClouds function below.
def jumpingOnClouds(c):
    last_cloud = len(c) - 1
    min_jumps = 0
    position = 0
    while position < last_cloud:
        if position + 2 < last_cloud and c[position + 2] == 0:
            position += 2
        else:
            position += 1
        min_jumps += 1
    return min_jumps


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())

    c = list(map(int, input().rstrip().split()))

    result = jumpingOnClouds(c)

    fptr.write(str(result) + '\n')

    fptr.close()
