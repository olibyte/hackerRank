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

    // Complete the migratoryBirds function below.
    static int migratoryBirds(List<int> arr)
    {
        var birdsCount = new Dictionary<int, int>();
        var maxMatch = new Dictionary<int, int>();

        foreach (var i in arr)
        {
            if (!birdsCount.ContainsKey(i))
                birdsCount.Add(i, 1);
            else
                birdsCount[i] = birdsCount[i] + 1;
        }

        int max = birdsCount.Values.Max();

        foreach (var i in birdsCount)
        {
            if (i.Value == max)
            {
                maxMatch.Add(i.Key, i.Value);
            }
        }
        return maxMatch.Keys.Min();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
