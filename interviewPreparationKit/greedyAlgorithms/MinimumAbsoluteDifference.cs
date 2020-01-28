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

    // Complete the minimumAbsoluteDifference function below.
    static int minimumAbsoluteDifference(int[] arr) {
        Array.Sort(arr); //sort the arr to ensure a[i] <= a[i+1]

        //var min = Math.Abs(arr[0] - arr[1]);
        var min = arr[1] - arr[0]; //initialise variable to store min dif

        for(int i = 1; i < arr.Length-1; i++)
        {
            //var abs = Math.Abs(arr[i] - arr[i+1]);
            var abs = arr[i+1] - arr[i]; //because arr is sorted, we no longer need to call Math.abs

            if (abs < min)
            {
                min = abs;
            }
        }
        return min;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int result = minimumAbsoluteDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
