# 2 evenly weighted die (fair)
# what is the probability that their sum will be at most 9?

# BRUTE FORCE
import math

def get_outcomes_totals(arr1,arr2):
    outcomes = []
    totals = []
    for i in range(len(arr1)):
        for j in range(len(arr2)):
            outcomes.append((arr1[i],arr2[j]))
            totals.append(arr1[i] + arr2[j])
    return outcomes, totals
def get_prob(arr, val):
    count = 0
    n = len(arr)
    for i in range(n):
        if arr[i] <= val:
            count += 1
    return count / n
def get_prob_more_dice(outcomes, totals, val):
    count = 0
    n = len(totals)
    for i in range(n):
        if totals[i] == val and outcomes[i][0] != outcomes[i][1]:
            count +=1
    return count / n
def compound_prob():
    return
D1 = [1,2,3,4,5,6]
D2 = [1,2,3,4,5,6]
o, t = get_outcomes_totals(D1,D2)
p = get_prob(t,9)
p2 = get_prob_more_dice(o,t,6)
print(o)
print(t)
print(p)
print(p2)