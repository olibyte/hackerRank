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

    // Complete the maximumSum function below.
    static long maximumSum(long[] a, long m) {
            long curr = 0;
            SortedDictionary<long, long> sDict = new SortedDictionary<long, long>();
            for (long i = 0; i < a.Length; i++)
            {
                curr = (a[i] % m + curr) % m;
                sDict[curr] = i;
            }
            var keyArr = sDict.Keys.ToArray();
            long max = keyArr.Last();
            for (long i = 0; i < sDict.Keys.Count - 1; i++)
            {
                if (sDict[keyArr[i]] > sDict[keyArr[i + 1]])
                    max = Math.Max(max, (keyArr[i] - keyArr[i + 1] + m) % m);
            }
            return max;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            long m = Convert.ToInt64(nm[1]);

            long[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt64(aTemp))
            ;
            long result = maximumSum(a, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
