# Input:
#  chessboard: A 2-dimensional array that represents.  Example below.
#  [[1, 0, 0, 0],
#  [0, 1, 0, 0],
#  [0, 0, 0, 1],
#  [0, 0, 0, 0]]
# Returns:
#  True if none of the rooks can attack each other.
#  False if there is at least one pair of rooks that can attack each other.
def rooks_are_safe(chessboard):
    n = len(chessboard) #assume chessboard is always square
    #check that there is no more than 1 rook present in any given column or row
    
    for row_i in range(n):
        row_count = 0 #no. of rooks i.e. 1's found
        for col_i in range(n):
            row_count += chessboard[row_i][col_i]
        if row_count > 1: #if there's more than one rook in the row
            return False
        
    for col_i in range(n):
        col_count = 0 #no. of rooks i.e. 1's found
        for row_i in range(n):
            col_count += chessboard[row_i][col_i]
        if col_count > 1: #if there's more than one rook in the column
            return False
    #no more than 1 rook present in in any given column or row
    return True
        
