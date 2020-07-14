#!/bin/python3

import math
import os
import random
import re
import sys
import time
# Complete the strangeCounter function below.
def strangeCounter(t):
    initial = 3
    while t > initial:
        t = t-initial
        initial *= 2

    return initial-t+1

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    t = int(input())

    result = strangeCounter(t)

    fptr.write(str(result) + '\n')

    fptr.close()
