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

class Solution {
    static long getElementsToTheLeft(int[] h, int index) {
        int count = 0;
        for (int i = index - 1; i >=0; i--)
        {
            if (h[i] < h[index]) {
                break;
            }
            count++;
        }
        return count;
    }
    static long getElementsToTheRight(int[] h, int index) {
        int count = 0;
        for (int i = index+1; i < h.Length; i++)
        {
            if (h[i] < h[index]) {
                break;
            }
            count++;
        }
        return count;
    }
    // Complete the largestRectangle function below.
    static long largestRectangle(int[] h) {
        long max = long.MinValue;
        long current;
        for (int i = 0; i < h.Length; i++)
        {
            current = (getElementsToTheLeft(h, i) + getElementsToTheRight(h, i) + 1) * h[i];
            max = (current > max) ? current : max;
        }
        return max;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
        ;
        long result = largestRectangle(h);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
