# Input: A 2-dimensional array with integers.  Example below.
#[[-4, -3, -1, 1],
# [-2, -2,  1, 2],
# [-1,  1,  2, 3],
# [ 1,  2,  4, 5]]
# Returns:
#  The number of negative numbers in the array.
#  In the above case, this function should return 6
#  since there are 6 negative numbers in the array.
#brute force 0(n**2)
def count_negatives(given_array):
    count = 0
    for i in range(len(given_array)):
        for j in range(len(given_array[i])):
            if given_array[i][j] < 0:
                count += 1
    return count
#O(n) solution can determine the number of negative values based on the first negative instance it meets
def count_negatives(given_array):
    count = 0
    row_i = 0
    col_i = len(given_array[0]) - 1 #determine row length or number of candidates in the row
    while col_i >= 0 and row_i < len(given_array): #while there are columns and rows / candidates
        if given_array[row_i][col_i] < 0: #going from right to left, once a negative cell is found
            count += (col_i + 1) #you can determine the number of negative cells in this row by adding 1 to the cell's column index
            row_i += 1 #once the number is added to the count, move down to the next row
        else:
            col_i -= 1 #otherwise move left to the next cell

    return count
