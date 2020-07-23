# Enter your code here. Read input from STDIN. Print output to STDOUT

import sys

n = int(input())
vals = sorted([])
for line in sys.stdin:
    query = tuple(int(x) for x in line.split())
    # print(vals)
    if query[0] == 1:
        vals.append(query[1])
        # vals.sort()
    elif query[0] == 2:
        # val to remove == query[1]
        # vals.(query[1])
        vals.remove(query[1])
        # print(vals)
    else:
        print(vals[0])

#         h= sortedlist([])
# for _ in range(int(input())):
#     inp = list(map(int,input().split()))
#     if inp[0] == 1:
#         h.append(inp[1])
#     elif inp[0] == 2:
#         h.remove(inp[1])
#     elif inp[0] == 3:
#         print(h[0])
