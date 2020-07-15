#!/bin/python3

import math
import os
import random
import re
import sys

def camelcase(s):
    #EDGE CASE, empty string
    if s == '':
        return 0
    else:
        count = 1
    chars = list(s) #convert s to list
    for c in chars: #walk through each char
        if c == c.upper(): # is c an uppercase char?
            count += 1
    return count

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    result = camelcase(s)

    fptr.write(str(result) + '\n')

    fptr.close()
