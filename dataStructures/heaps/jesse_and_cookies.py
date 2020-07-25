#!/bin/python3

import os
import sys
import heapq

#
# Complete the cookies function below.
#
def cookies(k, A):
    # treats = Heap()
    heapq.heapify(A)
    steps = 0
    while len(A) >= 2 and A[0] < k:
        a = heapq.heappop(A)
        b = heapq.heappop(A)
        heapq.heappush(A, a + 2 * b)
        steps += 1

    if A[0] >= k:
        return steps
    else:
        return -1

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    nk = input().split()

    n = int(nk[0])

    k = int(nk[1])

    A = list(map(int, input().rstrip().split()))

    result = cookies(k, A)

    fptr.write(str(result) + '\n')

    fptr.close()
