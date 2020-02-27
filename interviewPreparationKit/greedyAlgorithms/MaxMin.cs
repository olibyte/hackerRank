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

    // Complete the maxMin function below.
    static int maxMin(int k, int[] arr)
    {
        Array.Sort(arr);
        int minUnfairness = int.MaxValue;

        for (int i = 0; i < arr.Length - k + 1; i++)
        {
            int possibleMin = arr[i + k - 1] - arr[i];
            if (possibleMin < minUnfairness)
            {
                minUnfairness = possibleMin;
            }
        }
        return minUnfairness;

    }
    //using IENumerable class
    // static int maxMin(int k, int[] arr)
    // {
    //     // By sorting you minimise the distance between the smallest and largest numbers in a subarray
    //     var sortedNumbers = arr.OrderBy(x => x).ToList();
    //     var minUnfairness = Int32.MaxValue;

    //     for (var idx = 0; idx < arr.Length - k + 1; ++idx)
    //     {
    //         var min = sortedNumbers[idx];
    //         var max = sortedNumbers[idx + k - 1];
    //         var diff = max - min;
    //         if (diff < minUnfairness) minUnfairness = diff;
    //     }

    //     return minUnfairness;
    // }


    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int k = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            arr[i] = arrItem;
        }

        int result = maxMin(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
