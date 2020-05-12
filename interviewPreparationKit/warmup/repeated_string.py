#!/bin/python3

import math
import os
import random
import re
import sys
from collections import Counter

def getFrequencyA(my_string):
    count = dict(Counter(my_string))

    keys = count.keys()

    if 'a' in keys:
        answer = count['a']
    else:
        answer = 0
    return answer
# Complete the repeatedString function below.
def repeatedString(s, n):
    if len(s) == 1 and s != 'a':
        answer = 0
    elif len(s) == 1 and s == 'a':
        answer = n
    elif len(s) > n:
        new_string = list(s[:n])
        
        answer = getFrequencyA(new_string)
    else:
        loop_num = n // len(s)
        mod_num = n % len(s)

        new_string = ''

        for i in range(loop_num):
            new_string = new_string + s
        new_string = new_string + s[:mod_num]

        new_string = list(new_string)

        answer = getFrequencyA(new_string)

    return answer
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    n = int(input())

    result = repeatedString(s, n)

    fptr.write(str(result) + '\n')

    fptr.close()
