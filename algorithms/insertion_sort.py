#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the insertionSort1 function below.
def insertionSort1(n, arr):
    tmp = arr[n-1]
    for i in range(n-1,0,-1):
        if tmp < arr[i-1]:
            arr[i]=arr[i-1]
        elif tmp > arr[i-1]:
            arr[i]=tmp
            break;
        for i in arr:
            print(i,end=" ")
        print(" ")
    if tmp < arr[0]:
        arr[0]=tmp;
    for i in (arr):
        print(i, end= " ")
if __name__ == '__main__':
    n = int(input())

    arr = list(map(int, input().rstrip().split()))

    insertionSort1(n, arr)
