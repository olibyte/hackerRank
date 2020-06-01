#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the cavityMap function below.
def cavityMap(grid):
    grid = list(map(list, grid))
    for i in range(1, len(grid) -1): #i --> top, bottom
        for j in range(1, len(grid)-1): #j --> left,right
            if \
            grid[i-1][j] != 'X' and int(grid[i-1][j]) < int(grid[i][j]) and \
            grid[i+1][j] != 'X' and int(grid[i+1][j]) < int(grid[i][j]) and \
            grid[i][j-1] != 'X' and int(grid[i][j-1]) < int(grid[i][j]) and \
            grid[i][j+1] != 'X' and int(grid[i][j+1]) < int(grid[i][j]):
                grid[i][j] = 'X'

    return list(map(''.join, grid))

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())

    grid = []

    for _ in range(n):
        grid_item = input()
        grid.append(grid_item)

    result = cavityMap(grid)

    fptr.write('\n'.join(result))
    fptr.write('\n')

    fptr.close()
