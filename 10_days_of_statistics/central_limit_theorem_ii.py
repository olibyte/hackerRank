import math

'''
The number of tickets purchased by each student for the University X vs. University Y football game follows a distribution that has a mean mu of 2.4 and a standard deviation of sigma 2.0.

A few hours before the game starts, 100 eager students line up to purchase last-minute tickets. If there are only 250 tickets left, what is the probability that all 100 students will be able to purchase tickets?
'''
# tickets_left = float(input())
# students = float(input())
# mean = float(input())
# std = float(input())
tickets_left = 250
students = 100
mean = 2.4
std = 2.0

mean_dash = mean * students
std_dash = math.sqrt(students) * std

def cumulative(mean, std, value):
    return 0.5 * (1 + math.erf((value - mean) / (std * (2 ** 0.5))))

print(round(cumulative(mean_dash, std_dash, tickets_left),4))



