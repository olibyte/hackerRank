# A manufacturer of metal pistons finds that, on average, 12% of the pistons they manufacture are rejected because they are incorrectly sized. What is the probability that a batch of pistons will contain:

# No more than 2 rejects?
# At least 2 rejects?
# Define functions
def factorial(n):
    if n == 1 or n == 0:
        return 1
    if n > 1:
        return factorial(n - 1) * n

def binomial(x, n, p):
    f = factorial(n) / (factorial(n - x) * factorial(x))
    return (f * p**x * (1.0 - p)**(n-x))

# Set data
# values = list(map(float, input().split()))
values = [0.12,1]
# p = values[0] / (values[0] + values[1])
p = values[0]
n = 10

# Get binomial result
# no more than 2 i.e. 0 or 1.
result = binomial(0,n,p) + binomial(1,n,p) + binomial(2,n,p)
print(round(result, 3))
# at least 2
result = 0
for i in range(2,11):
    result += binomial(i,n,p)
print(round(result, 3))
