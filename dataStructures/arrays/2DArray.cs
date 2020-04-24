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

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        int hourGlassSum = 0;
        int maxValue = int.MinValue;
        // Outer loop to increment the row count up to row -2 to get hourglass shape
        for (int i = 0; i < arr.Length - 2; i++)
        {
            // inner loop to increment the column count up to column count -2 
            for (int j = 0; j < arr[i].Length - 2; j++)
            {
                //Console.WriteLine("({0},{1})",i,j);
                hourGlassSum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2];
                hourGlassSum += arr[i + 1][j + 1];
                hourGlassSum += arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                //Console.WriteLine(hourGlassSum);

                if (hourGlassSum > maxValue)
                {
                    maxValue = hourGlassSum;
                }
            }

        }
        return maxValue;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
