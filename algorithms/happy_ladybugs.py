#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the happyLadybugs function below.
def happyLadybugs(b):
    if b.count("_")>0:
        if b.count("_")==len(b):
            return "YES"
        else:
            letters = list(set(list(b)))
            letters.pop(letters.index("_"))
            for i in letters:
                if b.count(i)==1:
                    return "NO"
            return "YES"
    else:
        if len(b)==1:
            return "NO"
        else:
            counter = 0
            for i in range(len(b)):
                if i==len(b)-1:
                    if b[i]==b[i-1]:
                        counter = counter+1
                else:
                    if b[i]==b[i+1] or b[i]==b[i-1]:
                        counter = counter + 1
            if counter==len(b):
                return "YES"
            else:
                return "NO"
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    g = int(input())

    for g_itr in range(g):
        n = int(input())

        b = input()

        result = happyLadybugs(b)

        fptr.write(result + '\n')

    fptr.close()
