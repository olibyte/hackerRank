#!/bin/python3

import math
import os
import random
import re
import sys

#simple method is to use built-ins, something like this:

def bigSorting(unsorted):
    return sorted(unsorted, key=int)

#but very slow and will not execute within time limits. Better approach is to utilise the fact that big numbers will be longer strings
#specify a function that first sorts strings by length and sorts strings of the same length lexicographically.
#after that input all numbers as strings, sort them using comparer and output them in sorted order
# With this approach solutions using even slow interpreted languages such as Python fit into the time limit.

# n = int(input())
# a = []
# for i in range(n):
#     a.append(input())

# class StringAsInt(object):
#     def __init__(self, obj, *args):
#         self.obj = obj
#     def __lt__(self, other):
#         if len(self.obj) != len(other.obj):
#             return len(self.obj) < len(other.obj)
#         else:
#             return self.obj < other.obj
#     def __gt__(self, other):
#         return other < self
#     def __eq__(self, other):
#         return self.obj == other.obj
#     def __le__(self, other):
#         return not (self > other)
#     def __ge__(self, other):
#         return (other <= self)
#     def __ne__(self, other):
#         return self.obj != other.obj

# a.sort(key = StringAsInt)
# for x in a:
#     print(x)

import functools

def custom_compare(a, b):
    if len(a) < len(b):
        return -1
    if len(a) > len(b):
        return 1    
    if len(a) < 19:
        return int(a) - int(b)
    
    i = 0
    while True:
        # length of digits - less than max int
        a1 = a[i:i+18]
        b1 = b[i:i+18]

        i += 18

        inta1 = int(a1)
        intb1 = int(b1)

        if inta1 < intb1:
            return -1
        elif inta1 > intb1:
            return 1

        if len(a1) < 18:
            return 0

# Complete the bigSorting function below.
def bigSorting(unsorted):
    return sorted(unsorted, key=functools.cmp_to_key(custom_compare))

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())

    unsorted = []

    for _ in range(n):
        unsorted_item = input()
        unsorted.append(unsorted_item)

    result = bigSorting(unsorted)

    fptr.write('\n'.join(result))
    fptr.write('\n')

    fptr.close()