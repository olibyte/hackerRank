using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    // Complete the maxRegion function below.
    static int maxRegion(int[][] grid)
    {
        int maxRegionCounter = 0;

        for (int gridRow = 0; gridRow < grid.Length; gridRow++)
        {
            for (int gridColumn = 0; gridColumn < grid[gridRow].Length; gridColumn++)
            {
                // when find the first valid element, starts the deep search
                if (grid[gridRow][gridColumn] == 1)
                {
                    int foundRegion = calculateMaxRegion(grid, gridRow, gridColumn);

                    if (foundRegion > maxRegionCounter)
                        maxRegionCounter = foundRegion;
                }
            }
        }

        return maxRegionCounter;
    }

    static bool isValid(int[][] grid, int rowPosition, int columnPosition)
    {
        bool isValid;

        // validate if matrix limits are ok
        if (rowPosition < 0 || rowPosition >= grid.Length ||
          columnPosition < 0 || columnPosition >= grid[rowPosition].Length ||
          grid[rowPosition][columnPosition] == 0)
        {
            isValid = false;
        }
        else
        {
            isValid = true;
        }

        return isValid;
    }

    static int calculateMaxRegion(int[][] grid, int rowPosition, int columnPosition)
    {
        // validate if matrix limits are ok
        if (!isValid(grid, rowPosition, columnPosition))
        {
            return 0;
        }
        else
        {
            int maxRegion = 1;

            grid[rowPosition][columnPosition] = 0;

            for (int row = rowPosition - 1; row <= rowPosition + 1; row++)
            {
                for (int column = columnPosition - 1; column <= columnPosition + 1; column++)
                {
                    if (row != rowPosition || column != columnPosition)
                        maxRegion += calculateMaxRegion(grid, row, column);
                }
            }

            return maxRegion;
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] grid = new int[n][];

        for (int i = 0; i < n; i++)
        {
            grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
        }

        int res = maxRegion(grid);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
