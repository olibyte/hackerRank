# Enter your code here. Read input from STDIN. Print output to STDOUT
N = int(input())
X = list(map(int,input().split(' ')))
W = list(map(int,input().split(' ')))

def calculate_weighted_mean(n,x,w):
    numerator, denominator, weighted_mean = 0,0,0

    for i in range(n):
        numerator += X[i] * W[i]
        denominator += W[i]
    weighted_mean = round(numerator/denominator,1)
    
    return weighted_mean

print(calculate_weighted_mean(N,X,W))
