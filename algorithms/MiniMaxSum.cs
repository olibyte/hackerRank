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

    // Complete the miniMaxSum function below.
    static void miniMaxSum(int[] arr)
    {
        Int64 sum = 0;
        Int64 min = 0;
        Int64 max = 0;
        Array.Sort(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        min = sum - arr[arr.Length - 1];
        max = sum - arr[0];
        Console.Write(min + " " + max);
    }

    static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        miniMaxSum(arr);
    }
}
