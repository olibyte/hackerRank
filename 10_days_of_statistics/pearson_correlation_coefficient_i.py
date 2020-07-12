'''
Task
Given two n-element data sets, X and Y, calculate the value of the Pearson correlation coefficient.

Input Format
The first line contains an integer, n, denoting the size of data sets X and Y.
The second line contains n space-separated real numbers (scaled to at most one decimal place), defining data set X.
The third line contains n space-separated real numbers (scaled to at most one decimal place), defining data set Y.

Output
Print the value of the Pearson correlation coefficient, rounded to a scale of 3 decimal places.
'''

import math

n = 10
X = [10, 9.8, 8, 7.8, 7.7, 7, 6, 5, 4, 2]
Y = [200, 44, 32, 24, 22, 17, 15, 12, 8, 4]

X_mean = 6.73
X_std = 2.39251
Y_mean = 37.8
Y_std = 55.1993

numerator = 0
for i in range(0,n):
    numerator += ((X[i] - X_mean) * (Y[i] - Y_mean))
denominator = n * X_std * Y_std
result = numerator / denominator
print(round(result,3))