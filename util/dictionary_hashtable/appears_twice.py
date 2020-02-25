# Given a list of names, write a function that finds a name that appears twice in the list.
# For example, if you're given ['George', 'Tom', 'Emily', 'Jenny', 'Tom'], your function should return 'Tom'.

# Just assume that there's only one name that appears twice.

# Modify the following function:
def appears_twice(given_list):
    name_dict = {}
    for name in given_list:
        if name in name_dict:
            return name
        else:
            name_dict[name] = 1 
    return ''