# Given an integer, n, perform the following conditional actions:

# If  is odd, print Weird
# If  is even and in the inclusive range of 2 to 5, print Not Weird
# If  is even and in the inclusive range of 6 to 20, print Weird
# If  is even and greater than 20, print Not Weird
#!/bin/python3

import math
import os
import random
import re
import sys

if n % 2 == 1:
    print('Weird')
# elif n % 2 == 0:
if n >= 2 and n <= 5:
    print ('Not Weird')
elif n >= 6 and n <= 20:
    print('Weird')
else: 
    print('Not Weird')
if __name__ == '__main__':
    n = int(input().strip())
