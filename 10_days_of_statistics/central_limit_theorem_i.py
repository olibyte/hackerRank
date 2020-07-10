# Enter your code here. Read input from STDIN. Print output to STDOUT
import math

# max_weight = float(input()) #a large elevator can tranport a maximum of 9800 pounds
# n = float(input()) #suppose a load of cargo containing 49 boxes must be transported via the elevator
# mean_weight = float(input()) #the box weight of this type of cargo follows a distr with a mean of 205 pounds
# standard_deviation = float(input()) # and a standard deviation of 15 pounds

#what is the probability that all 49 boxes can be safely loaded into the freight elevator and transported?

max_weight = 9800
n = 49
mean_weight = 205 #mu
standard_deviation = 15 #sigma

mean_weight_dash = n * mean_weight
standard_deviation_dash = math.sqrt(n) * standard_deviation

def cumulative(mean, std, value):
    return 0.5 * (1 + math.erf((value - mean) / (std * (2 ** 0.5))))

# print('Max weight: {0}'.format(max_weight))
# print('Number of boxes: {0}'.format(number_of_boxes))
# print('Mean weight: {0}'.format(mean_weight))
# print('STD: {0}'.format(standard_deviation))
# print('Mean weight dash: {0}'.format(mean_weight_dash))
# print('Standard deviation dash: {0}'.format(standard_deviation_dash))

result = round(cumulative(mean_weight_dash, standard_deviation_dash,max_weight),4)
print(result)

