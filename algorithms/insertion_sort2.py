#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the insertionSort2 function below.


def insertionSort2(n, arr):
    for i in range(1, len(arr)):
        for j in range(i):
            temp = arr[i]
            if temp < arr[j]:
                arr[i] = arr[j]
                arr[j] = temp
        for i in arr:
            print(i, end=" ")
        print(" ")


if __name__ == '__main__':
    n = int(input())

    arr = list(map(int, input().rstrip().split()))

    insertionSort2(n, arr)
