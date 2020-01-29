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

    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr)
    {
        if (arr.Length == 0)
            return arr[0];

        int maxEvenSum = arr[0];
        int maxOddSum = Math.Max(maxEvenSum, arr[1]);

        for (int i = 2; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                maxEvenSum = Math.Max(Math.Max(maxEvenSum, maxOddSum), Math.Max(arr[i], arr[i] + maxEvenSum));
            }
            else
            {
                maxOddSum = Math.Max(Math.Max(maxEvenSum, maxOddSum), Math.Max(arr[i], arr[i] + maxOddSum));
            }
        }
        return Math.Max(maxEvenSum, maxOddSum);

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = maxSubsetSum(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
