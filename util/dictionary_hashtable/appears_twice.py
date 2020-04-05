# Given a list of names, write a function that finds a name that appears twice in the list.
# For example, if you're given ['George', 'Tom', 'Emily', 'Jenny', 'Tom'], your function should return 'Tom'.

# This function assumes that there's only one name that appears twice and returns an empty string if no name appears twice

# Modify the following function:
def appears_twice(given_list):
    name_dict = {} #initialise empty dictionary
    for name in given_list: #iterate through names in the list
        if name in name_dict: #if the name is already in the dictionary return the name
            return name
        else:
            name_dict[name] = 1 #otherwise set the value of the dictionary entry with that name as the key to 1
    return ''

#Test 1
names = ['George', 'Tom', 'Emily', 'Jenny', 'Tom']
print('The names variable is of type ' + str(type(names)))
print(appears_twice(names))
#Test 2 - name appears more than twice
names = ['Oliver', 'Oliver', 'Oliver']
print(appears_twice(names))
#Test 3 - no name appears twice
names = ['Oliver', 'Zara', 'Jayde']
print(appears_twice(names))
#Test 4 - more than one name appears twice, so it returns the first occurrence
names = ['Oliver', 'Oliver', 'Zara', 'Zara']
print(appears_twice(names))