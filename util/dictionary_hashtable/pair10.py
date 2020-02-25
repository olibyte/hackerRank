# Input: A list / array with integers.  For example:
# [3, 4, 1, 2, 9]
# Returns:
#  Nothing. However, this function will print out
#  a pair of numbers that adds up to 10. For example,
#  1, 9.  If no such pair is found, it should print
#  "There is no pair that adds up to 10.".
def pair10(given_list):
    numbers_seen = {}
    #numbers_seen = {3:1, 4:1, 1:1, 2:1, 9:1!} -> stop at given_list[4] == 9 since numbers_seen[2] ==  1
    for item in given_list:
        if (10 - item) in numbers_seen:
            print(str(10 - item) + ', ' + str(item)) #1, 9
            return
        else:
            numbers_seen[item] = 1      
    print("There is no pair that adds up to 10.")