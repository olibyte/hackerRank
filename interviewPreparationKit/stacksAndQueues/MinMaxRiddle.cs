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

public class Solution
{


    // Complete the riddle function below.
    static long[] riddle(long[] arr)
    {
        long[] result = new long[arr.Length];

        int n = arr.Length;

        //used to find prev and next smaller
        Stack<long> s = new Stack<long>();

        //arrays to store prev and next smaller
        long[] left = new long[n + 1];
        long[] right = new long[n + 1];

        //initialize elements of left[] and right[]
        for (int i = 0; i < n; i++)
        {
            left[i] = -1;
            right[i] = n;
        }

        //Fill left[] using logic discussed on https://www.geeksforgeeks.org/next-greater-element/
        for (int i = 0; i < n; i++)
        {
            while (!(s.Count == 0) && arr[s.Peek()] >= arr[i])
                s.Pop();
            if (s.Count != 0)
                left[i] = s.Peek();

            s.Push(i);
        }
        s.Clear();

        //Fill right[] using same logic
        for (int i = n - 1; i >= 0; i--)
        {
            while (!(s.Count == 0) && arr[s.Peek()] >= arr[i])
                s.Pop();
            if (s.Count != 0)
                right[i] = s.Peek();

            s.Push(i);
        }
        long[] ans = new long[n + 1];
        for (int i = 0; i <= n; i++)
            ans[i] = 0;

        //Fill ans[] by comparing mins of all lengths computed using left[] and right[]
        for (int i = 0; i < n; i++)
        {
            //length of interval
            long len = right[i] - left[i] - 1;

            //arr[i] is possible answer for this length, 'len' interval, check if arr[i] is greater than max for 'len'
            ans[len] = Math.Max(ans[len], arr[i]);
        }
        //Some entries in ans[] may not be filled yet. Fill them by taking values from right side of ans[]
        for (int i = n - 1; i >= 1; i--)
            ans[i] = Math.Max(ans[i], ans[i + 1]);

        for (int i = 1; i <= n; i++)
            result[i - 1] = ans[i];
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        long[] res = riddle(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
