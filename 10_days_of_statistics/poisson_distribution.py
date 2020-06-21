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
e = 2.71828
def poisson(k,lam):
    return (lam**k) * (e**(-lam)) / factorial(k)
result = 0 
# result = poisson(3,2)
# print(round(result,3))
# for i in range(0,4):
#         result += poisson(i,5)
# print(round(result,3))
result = poisson(5,2.5)
print(round(result,3))