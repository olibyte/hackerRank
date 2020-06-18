def factorial(n):
    if n == 1 or n == 0:
        return 1
    if n > 1:
        return factorial(n - 1) * n

def binomial(x, n, p):
    f = factorial(n) / (factorial(n - x) * factorial(x))
    return (f * p**x * (1.0 - p)**(n-x))

def negative_binomial(x,n,p):
    f = factorial(n-1) / (factorial(n - 1 - x) * factorial(x - 1))
    return (f * p**x * (1.0 - p)**(n-x))
def geometric(n,p):
    q = 1.0 - p
    return (q**(n-1) * p)
values = [1,3]
p = values[0] / values[1]
n = 5
# print(('{} {}').format(values[0],values[1]))
# print(negative_binomial(1,n,p))
result = 0 
for i in range(n+1):
    if i > 0:
        result += geometric(i,p)
print(round(result,3))