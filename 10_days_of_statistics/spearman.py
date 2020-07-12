# Define functions
def rank(dt):
    rank = {}
    sort = sorted(dt)
    for i in range(len(dt)):
        for j in range(len(sort)):
            if dt[i] == sort[j]:
                rank[dt[i]] = j + 1
    return rank

def spearman(x, y, rx, ry, n):
    diff_rank = 0
    for i in range(n):
        if rx[x[i]] != ry[y[i]]:
            diff_rank = diff_rank + ((rx[x[i]] - ry[y[i]]) ** 2)
    return (6 * diff_rank) / (n ** 3 - n)

##HARD-CODE FOR TESTING###
n = 10
data_set_x = [10, 9.8, 8, 7.8, 7.7, 7, 6, 5, 4, 2]
data_set_y = [200, 44, 32, 24, 22, 17, 15, 12, 8, 4]


# Set data
n = int(float(input()))
data_set_x = list(map(float, input().split()))
data_set_y = list(map(float, input().split()))

# Get rank
rank_x = rank(data_set_x)
rank_y = rank(data_set_y)

# Gets the result and show on the screen
s = spearman(data_set_x, data_set_y, rank_x, rank_y, n)
print(round(1 - s, 3))
