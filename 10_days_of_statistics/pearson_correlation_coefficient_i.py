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
# print(round(result,3))

'''
rx = 3x + 4y + 8 = 0
ry = 4x + 3y + 7
'''
def rx(a,b):
    return 3*a + 4*b + 8
def ry(a,b):
    return 4*a + 3*b + 7


for i in range(1,10):
    X += rx(i,i)
    Y += rx(i,i)
print(X)
print(Y)