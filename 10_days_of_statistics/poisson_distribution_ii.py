# Enter your code here. Read input from STDIN. Print output to STDOUT
def dailyCost(l):
    return l + l**2
a = 160 + 40 * dailyCost(0.88)
b = 128 + 40 * dailyCost(1.55)
print(round(a,3))
print(round(b,3))