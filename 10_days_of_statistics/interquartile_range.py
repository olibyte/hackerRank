import os
import math


def median(arr):
    n = len(arr) - 1
    if n <= 0:
        return 0
    return (arr[math.floor(n / 2)] + arr[math.ceil(n / 2)]) / 2


def quartiles(arr):
    n = len(arr)
    q1 = median(arr[:n // 2])
    q2 = median(arr)
    q3 = median(arr[math.ceil(n / 2):])
    return q1, q2, q3


def interquartile_range(arr):
    q1, _, q3 = quartiles(arr)
    return q3 - q1


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())
    arr = list(map(int, input().rstrip().split()))
    freq = list(map(int, input().rstrip().split()))

    s = []
    for i in range(0, n):
        s += freq[i] * [arr[i]]
    s.sort()

    iq = interquartile_range(s)

    fptr.write('{:.1f}\n'.format(iq))
    fptr.close()