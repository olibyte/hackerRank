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

    // Complete the plusMinus function below.
    static void plusMinus(int[] arr)
    {
        double count = arr.Length;
        double positive = 0;
        double negative = 0;
        double zero = 0;

        foreach (var item in arr)
        {
            if (item > 0) positive++;
            else if (item == 0) zero++;
            else negative++;
        }

        Console.WriteLine(positive / count);
        Console.WriteLine(negative / count);
        Console.WriteLine(zero / count);

    }
// static int calculatePositives(int[] arr, int size)
// {
//     int positives = 0;

//     for(int i = 0; i < size; i++)
//     {
//         if(arr[i] > 0)
//         {
//             positives++;
//         }
//     }
//     return positives;
// }
// static int calculateNegatives(int[] arr, int size)
// {
//     int negatives = 0;

//     for(int i =0; i < size; i++)
//     {
//         if(arr[i] < 0)
//         {
//             negatives++;
//         }
//     }
//     return negatives;
// }
// static int calculateZeros(int[] arr, int size)
// {
//     int zeros = 0;

//     for(int i = 0; i < size; i++)
//     {
//         if(arr[i] == 0)
//         {
//             zeros++;
//         }
//     }
//     return zeros;
// }

static void Main(string[] args)
{
    int n = Convert.ToInt32(Console.ReadLine());

    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
    ;
    plusMinus(arr);
}
}
