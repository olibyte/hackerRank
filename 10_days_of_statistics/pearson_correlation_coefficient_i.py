import math
def standard_deviation(arr):
    n = len(arr)
    mu = calculate_mean(arr)
    x = 0
    for i in range(0,len(arr)):
        x += math.pow((arr[i] - mu),2)
    sigma = math.sqrt(x / n)
    return sigma
def calculate_mean(arr):
    mean = 0
    n = len(arr)
    for i in range(n):
        mean += arr[i]
    return mean/n

n = int(input())
X = list(map(float, input().split()))
Y = list(map(float, input().split()))

X_mean = calculate_mean(X)
X_std = standard_deviation(X)
Y_mean = calculate_mean(Y)
Y_std = standard_deviation(Y)

numerator = 0
for i in range(0,n):
    numerator += ((X[i] - X_mean) * (Y[i] - Y_mean))
denominator = n * X_std * Y_std
result = numerator / denominator
print(round(result,3))
