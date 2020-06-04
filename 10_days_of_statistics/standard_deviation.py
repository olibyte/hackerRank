# Enter your code here. Read input from STDIN. Print output to STDOUTimport math
import os
import math

def calculate_mean(arr):
    mean = 0
    n = len(arr)
    for i in range(n):
        mean += arr[i]
    return mean/n

def standard_deviation(arr):
    n = len(arr)
    mu = calculate_mean(arr)
    x = 0
    for i in range(0,len(arr)):
        x += math.pow((arr[i] - mu),2)
    sigma = math.sqrt(x / n)
    return sigma

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())
    arr = list(map(int, input().rstrip().split()))
    
    std = standard_deviation(arr)

    fptr.write('{:.1f}\n'.format(std))
    fptr.close()
