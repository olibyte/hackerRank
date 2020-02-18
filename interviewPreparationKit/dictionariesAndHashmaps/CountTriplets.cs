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

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r)
    {
        Dictionary<long, long> count = new Dictionary<long, long>();
        Dictionary<long, long> twins = new Dictionary<long, long>();
        long result = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            long element = arr[i];
            if (element % r == 0)
            {
                long prev = element / r;
                if (twins.ContainsKey(prev))
                {
                    result += twins[prev];
                }
                if (count.ContainsKey(prev))
                {
                    if (twins.ContainsKey(element))
                    {
                        twins[element] += count[prev];
                    }
                    else
                    {
                        twins[element] = count[prev];
                    }
                }
                else
                {
                    twins[element] = 0;
                }
            }
            if (count.ContainsKey(element))
            {
                count[element]++;
            }
            else
            {
                count[element] = 1;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
