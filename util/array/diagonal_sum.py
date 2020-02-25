# Modify the following function:
def diagonal_sum(given_2d):
    total = 0
    for i in range(len(given_2d)):
        total += given_2d[i][i]
    return total