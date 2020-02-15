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
    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr)
    {
        if (arr.Length < 2) return 0; //can't swap if there's less than 2 elements in the array.

        int minimumSwaps = 0;
        int index = 0;
        while (index < arr.Length) //walk
        {
            if (arr[index] == index + 1) //
            {
                index++;
                continue;
            }
            Swap(arr, index, (arr[index] - 1)); //otherwise swap index with element to the left
            minimumSwaps++;
        }
        return minimumSwaps;
    }
    static void Swap(int[] array, int leftIndex, int rightIndex)
    {
        int temp = array[leftIndex];
        array[leftIndex] = array[rightIndex];
        array[rightIndex] = temp;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
