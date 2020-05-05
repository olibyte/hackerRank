//HACKERRANK ALGORITHMS: MEMOIZATION AND DYNAMIC PROGRAMMING SOLUTION TO THE NUMBER OF PATHS PROBLEM
//NON-MEMOIZED IMPLEMENTATION
int CountPaths(bool[][] grid, int row, int col)
{
    if (!ValidSquare(grid,row,col)) return 0;
    if(isAtEnd(grid,row,col)) return 1;
    //note that the x coordinate corresponds to the column, and y to the row
    //grid[row][col] is equivalent to grid[y][x], NOT grid[x][y]
    return CountPaths(grid, row+1,col) + CountPaths(grid,row,col+1); //can either move 1 cell down or right
}
//MEMOIZED
int CountPaths(bool[][] grid, int row, int col, int [][] paths )
{
    if (!ValidSquare(grid,row,col)) return 0;
    if(isAtEnd(grid,row,col)) return 1;
    if (paths[row][col] == 0)
    {
        paths[row][col] = CountPaths(grid, row+1, col) + CountPaths(grid, row, col+1);
    }
    return paths[row][col];

}