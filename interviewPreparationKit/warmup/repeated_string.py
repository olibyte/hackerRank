#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the repeatedString function below.
def repeatedString(s, n):
    # edge cases, if s is only 1 character long.
    s_length = len(s)
    if s_length == 1:
        if s == 'a':
            return n
        else:
            return 0

    frequency = 0
    multiplier = n // s_length
    remainder = n % s_length
    
    s_frequency = s.count('a')
    remainder_frequency = s[:remainder].count('a')
    frequency = (s_frequency * multiplier) + remainder_frequency
     
    return frequency

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    n = int(input())

    result = repeatedString(s, n)

    fptr.write(str(result) + '\n')

    fptr.close()
