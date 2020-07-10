import math
def calculate_mean(arr):
    mean = 0
    n = len(arr)
    for i in range(n):
        mean += arr[i]
    return mean/n

def standard_deviation(arr):
    n = len(arr)
    mu = calculate_mean(arr)
    x = 0
    for i in range(0,len(arr)):
        x += math.pow((arr[i] - mu),2)
    sigma = math.sqrt(x / n)
    return sigma
e = 2.71828
def error_function(z):
    e = 2.71828
    t = 1.0/(1.0 + 0.5*abs(z))
    expo = e**(-z*z - 1.26551223 + t * ( 1.00002368 + t * ( 0.37409196 + t * ( 0.09678418 + t * (-0.18628806 + t * ( 0.27886807 + t * (-1.13520398 + t * ( 1.48851587 + t * (-0.82215223 + t * ( 0.17087277))))))))))
    x = 1 - t*expo
    if (z >= 0):
        return  x
    else: 
        return -x
def cumulative_dist_normal(x, mu, sigma):
    error_input = (x-mu)/(sigma*math.sqrt(2))
    return 0.5*(1 + error_function(error_input))
upper_bound = 19.5
lower_bound = 0
result = cumulative_dist_normal(upper_bound,20,2) - cumulative_dist_normal(lower_bound,20,2)
print(round(result,3))
upper_bound = 22
lower_bound = 20
result = cumulative_dist_normal(upper_bound,20,2) - cumulative_dist_normal(lower_bound,20,2)
print(round(result,3))