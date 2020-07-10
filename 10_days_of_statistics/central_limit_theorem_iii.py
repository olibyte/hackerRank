'''
You have a sample of 100 values from a population with mean mu = 500 and with standard deviation sigma 80. Compute the interval that covers the middle 95% of the distribution of the sample mean; in other words, compute A and B such that P(A < x < B) = 0.95. Use the value of z = 1.96. Note that z is the z-score.
'''
import math

n = 100
mean = 500
std = 80
interval = 0.95
z = 1.96

computed_interval = z * (std / math.sqrt(n))

a = mean - computed_interval
b = mean + computed_interval
print(round(a, 2))
print(round(b, 2))
