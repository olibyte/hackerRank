# Input:
#  a: The given list/array of integers.  Example: [1, -2, 3, 4]
# Returns:
#  The second largest number in the list or None if
#  the array's length is only 1 or 2.
def second_largest(given_list):
    length = len(given_list)
    if(length < 2):
        return None
    else:
        given_list.sort()
        return given_list[length - 2]

#naive implementation
# def second_largest(given_list):
#     largest = None
#     second_largest = None
#     for current_number in given_list:
#         if largest == None:
#             largest = current_number  #first number in array is largest
#         elif current_number > largest: 
#             second_largest = largest
#             largest = current_number #current number is new largest
#         elif second_largest == None: 
#             second_largest = current_number
#         elif current_number > second_largest:
#             second_largest = current_number
#     return second_largest
