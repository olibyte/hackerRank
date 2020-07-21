import sys
    
n = int(input())
vals = [0]
for line in sys.stdin:
    query = tuple(int(x) for x in line.split())
    if query[0] == 1:
        vals.append(max(vals[-1], query[1]))
    elif query[0] == 2:
        vals.pop()
    else:
        print(vals[-1])