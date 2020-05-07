#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the countingValleys function below.
def countingValleys(n, s):
    level = 0
    prev_height = 0
    count = 0
    for i in range(0,n):
        if s[i] == 'D':
            level -= 1
        if s[i] == 'U':
            level += 1
    #if we return to level having just been previously below level
    #we were in a valley 
        if level == 0 and prev_height < 0:
            count+=1
        prev_height = level #remember to keep track of our previous level

    return count

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())

    s = input()

    result = countingValleys(n, s)

    fptr.write(str(result) + '\n')

    fptr.close()
