#!/bin/python3
import math
import os
import random
import re
import sys
# Complete the superReducedString function below.
def superReducedString(s):
    reduced = []

    for i in s:
        if not reduced:
            reduced.append(i)
        elif reduced[-1] == i:
            reduced.pop(-1)
        else:
            reduced.append(i)
    if not reduced:
        return "Empty String"
    else:
        return "".join(reduced)


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    result = superReducedString(s)

    fptr.write(result + '\n')

    fptr.close()

'''
Steve has a string of lowercase characters in range ascii[‘a’..’z’]. He wants to reduce the string to its shortest length by doing a series of operations. In each operation he selects a pair of adjacent lowercase letters that match, and he deletes them. For instance, the string aab could be shortened to b in one operation.

Steve’s task is to delete as many characters as possible using this method and print the resulting string. If the final string is empty, print Empty String

Function Description
Complete the superReducedString function in the editor below. It should return the super reduced string or Empty String if the final string is empty.

superReducedString has the following parameter(s):
s: a string to reduce

Input Format
A single string, s.

Contraints
1 <= |s| <= 100

Ouput
If the final string is empty, print Empty String; otherwise, print the final non-reducible string.

Sample:
aaabccddd => abd
'''
