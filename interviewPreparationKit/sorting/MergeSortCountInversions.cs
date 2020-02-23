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

    // Complete the countInversions function below.
    static long countInversions(int[] arr)
    {
        int[] aux = (int[])arr.Clone();
        return countInversions(arr, 0, arr.Length - 1, aux);
    }
    static long countInversions(int[] arr, int low, int high, int[] aux)
    {
        if (low >= high)
        {
            return 0;
        }
        int mid = low + (high - low) / 2;
        long count = 0;
        count += countInversions(aux, low, mid, arr);
        count += countInversions(aux, mid + 1, high, arr);
        count += Merge(arr, low, mid, high , aux);

        return count;
    }
    static long Merge(int[] arr, int low, int mid, int high, int[] aux)
    {
        long count = 0;
        int i = low, j = mid + 1, k = low;
        while(i <= mid || j <= high)
        {
            if (i > mid)
            {
                arr[k++] = aux[j++];
            }
            else if (j > high)
            {
                arr[k++] = aux[i++];
            }
            else if (aux[i] <= aux[j])
            {
                arr[k++] = aux[i++];
            }
            else
            {
                arr[k++] = aux[j++];
                count += mid + 1 - i;
            }
        }
        return count;
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            long result = countInversions(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
