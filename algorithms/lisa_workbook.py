#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the workbook function below.
def workbook(n, k, arr):
    page_no = 1
    counter = 0
    for num_of_problem in arr:
        i = 0
        number_of_pages_in_chapter = num_of_problem // k #each page can hold up to k problems. the integer division here is no. of full pages.
        if num_of_problem % k != 0:
            number_of_pages_in_chapter += 1 #use modulo for pages that aren't quite full.
        while i < number_of_pages_in_chapter:
            p1 = i * k + 1
            p2 = (i+1) * k
            if p2 > num_of_problem:
                p2 = num_of_problem
            if p1 <= page_no <= p2:
                counter += 1
            print(counter, page_no, p1, p2)
            page_no += 1
            i += 1

    return counter
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    nk = input().split()

    n = int(nk[0])

    k = int(nk[1])

    arr = list(map(int, input().rstrip().split()))

    result = workbook(n, k, arr)

    fptr.write(str(result) + '\n')

    fptr.close()
